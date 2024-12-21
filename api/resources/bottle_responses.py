from flask import Flask, request, jsonify, Response
from flask_restful import Resource, Api, reqparse
from werkzeug.utils import secure_filename
from PIL import Image
from bottle.models.yolo_bottle import YoloBottle 
from flask_injector import FlaskInjector, singleton
from injector import inject
import json

        
class BottleResponse(Resource):
    def __init__(self, **kwargs ):
        self.model = kwargs['model']
    
    def post(self):
        image = request.files['image']
        (valid, error) = self.validaImagem(image)
        if valid == False:
            return Response(
                response=json.dumps(error.__dict__),
                status=400,
                mimetype='application/json'
            ) 
        try:
            #nom_image = secure_filename(image.filename)
            im = Image.open(image)
            status, confidence, existBottle, elapsed = self.model.predict(im)
            if existBottle == False:
                status = "notExists"
                confidence = 1
            elif status:
                status = "close"
            else:
                status = "open"
        except Exception as err:
            return Response(
                response=json.dumps(ErrorResponse(err.args[0]).__dict__),
                status=500,
                mimetype='application/json'
            ) 
        
        return Response(
            response= json.dumps(ClassificationResponse(status, confidence, elapsed).__dict__),
            status = 200,
            mimetype='application/json'
        )
        
    

    def validaImagem(self, image):
        valid = True
        error = None
        if image.name =='':
            error = ErrorResponse("A imagem não foi enviada. ")
            valid = False
        else:
            extensionsToCheck = ('.jpg', '.jpeg', '.png', ".bmp")
            if image.filename.endswith(extensionsToCheck) == False:  
                error = ErrorResponse("O arquivo enviado não é uma imagem.")
                valid = False            
        return (valid, error)

class ErrorResponse:
    def __init__(self, message:str):
        self.Error = message

class ClassificationResponse:
    def __init__(self, bottleStatus, confidence, elapsedTime ):
        self.Bottle_Status= bottleStatus
        self.Confidence = confidence
        self.ElapsedTime = elapsedTime