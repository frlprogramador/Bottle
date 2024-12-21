from flask import Flask, request, Response
from flask_restful import Resource, Api, reqparse
from werkzeug.utils import secure_filename
from PIL import Image
from bottle.models.yolo_bottle import YoloBottle 
import json
import logging

        
class BottleResponse(Resource):
    def __init__(self, **kwargs ):
        self.logger = logging.getLogger(__name__)
        self.logger.info("Create BottleResponse")
        self.model = kwargs['model']

    
    def post(self):
        self.logger.info("Post Received")
        image = request.files['image']
        self.logger.debug("Image [File Name]: " + image.filename)
        
        self.logger.info("Before  imageValidation: " + image.filename)

        (valid, error) = self.imageValidation(image)
        self.logger.debug("After  imageValidation: (valid, error): (" + str(valid) + ", "  + str( error.Error if error != None else "" ) + ")")

        if valid == False:
            self.logger.error("Response: (400) -> " + json.dumps(error.__dict__) )

            return Response(
                response=json.dumps(error.__dict__),
                status=400,
                mimetype='application/json'
            ) 
        try:
            im = Image.open(image)
            self.logger.debug("Open Image size: " + str(im.size))
            
            status, confidence, existBottle, elapsed = self.model.predict(im)
            self.logger.info("After Predict (status, confidence, existsBottle, elapsed): " + str(status) + ", " + str(confidence) + ", " + str(existBottle) + ", " + str(elapsed) + ")")

            if existBottle == False:
                status = "notExists"
                confidence = 1
            elif status:
                status = "close"
            else:
                status = "open"
        except Exception as err:
            e = ErrorResponse(err.args[0])
            self.logger.error("Response Error: (500) -> " + json.dumps(e.__dict__) )
            return Response(
                response=json.dumps(e.__dict__),
                status=500,
                mimetype='application/json'
            ) 
        classification = ClassificationResponse(status, confidence, elapsed)
        self.logger.info("Response Ok: (200) -> " + json.dumps(classification.__dict__) )
        return Response(
            response= json.dumps(classification.__dict__),
            status = 200,
            mimetype='application/json'
        )
        
    

    def imageValidation(self, image):
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