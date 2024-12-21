from dotenv import load_dotenv
from bottle.models.yolo_bottle import YoloBottle
from flask import Flask, request
from flask_restful import Api
import os
from api.resources.bottle_responses import BottleResponse
from bottle.models.yolo_bottle import YoloBottle
import logging

app = Flask(__name__)
api = Api(app)


def main():
    load_dotenv()
    logger = configLog()

    logger.info('Before Create Model YoloBottle')
    model = YoloBottle()
    logger.info('After Create Model YoloBottle')


    api.add_resource(BottleResponse, '/bootle',
                     resource_class_kwargs={ 'model': model })

    app.run(debug=True, port=os.environ['PORT'])



def configLog():
    logger = logging.getLogger(__name__)
    logging.basicConfig(filename=os.environ["LOG_FILE_PATH"], encoding='utf-8', level=logging.DEBUG)
    logger.info('Config Log Finished')

    return logger

    #logger.debug('This message should go to the log file')
    #logger.info('So should this')
    #logger.warning('And this, too')
    #logger.error('And non-ASCII stuff, too, like Øresund and Malmö')



def configure(binder):
    binder.bind(YoloBottle, to=YoloBottle(), scope=singleton)


if __name__ == '__main__':
    main()


        
    


    