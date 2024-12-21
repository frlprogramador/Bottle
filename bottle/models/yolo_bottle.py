from ultralytics import YOLO
import torch
import os
import time
import logging
import pandas as pd

class YoloBottle:
    def __init__(self):

        self.logger = logging.getLogger(__name__)
        
        self.logger.info('Available Cuda')
        if torch.cuda.is_available():
            self.logger.info('Cuda is active')
            self.device = torch.device("cuda")
            self.logger.info('Set Device Cuda')
        else:
            self.logger.info('Cuda is inactive')
            self.device = torch.device("cpu")
            self.logger.info('Set Device CPU')
        
        self.logger.info('Before Load Model YOLO')
        self.model = YOLO(os.environ["MODEL"]).to(self.device)
        self.logger.info('After Load Model YOLO')

        self.logger.info('Before Load Parameters CONFIDENCES')
        self.threshold_cap = float(os.environ["TH_CONFIDENCE_CAP"])
        self.threshold_bottle = float(os.environ["TH_CONFIDENCE_BOTTLE"])
        self.logger.info('After Load Parameters CONFIDENCES')

    
    def predict(self, image):
        start = time.time()
        
        
        self.logger.debug('Start predict: ' + str(self.convert_to_hms_format(start)))


        self.logger.debug('Before Predict')
        results = self.model.predict(image)
        self.logger.debug('After Predict')

        existCap = False
        confidence = 0
        confidenceOpen = 0
        existBottle = False


        self.logger.debug('Results Len: ' + str(len(results)))


        for result in results:
            boxes = result.boxes  # Boxes object for bounding box outputs
            for box in boxes:
                if box.cls == 1: ##Cap
                    self.logger.debug('Box Cap found in Box - Confidence = ' + str(float(box.conf)))
                    if box.conf > self.threshold_cap:                       
                        existCap = True
                        if box.conf > confidence:                        
                            confidence = float(box.conf)                       
                else:
                    if box.conf > self.threshold_bottle:

                        self.logger.debug('Bootle found in Box - Confidence = ' + str(float(box.conf)))
                        existBottle = True
                        if box.conf > confidenceOpen:
                            confidenceOpen = float(box.conf) 
            if existCap == False:
                confidence = confidenceOpen
        done = time.time()
        self.logger.debug('Done predict: ' + str(self.convert_to_hms_format(done)))
 
        elapsed = done - start
        self.logger.debug('Elapsed predict: ' + str(self.convert_to_hms_format(elapsed)))

        self.logger.debug('Return Predict: (existCap, confidence, existBottle, elapsed) =  (' +  str(existCap) + ", " +  str(confidence) + ", " + str(existBottle) + ", " + str(elapsed) + ")")


        return (existCap, confidence, existBottle, elapsed)
    
    def convert_to_hms_format(self, sec):
        sec = sec % (24 * 3600)
        hour = sec // 3600
        sec %= 3600
        min = sec // 60
        sec %= 60
        return "%02d:%02d:%02d" % (hour, min, sec) 
    
                        
            
        