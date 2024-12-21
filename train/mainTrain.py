from ultralytics import YOLO
import torch

if torch.cuda.is_available():
    device = torch.device("cuda")
else:
    device = torch.device("cpu")
model = YOLO("yolo11x.pt")

if __name__ == '__main__':
    freeze = 24
    freeze = [f"model.{x}." for x in range(freeze)]  # layers to freeze
    for k, v in model.named_parameters():
        v.requires_grad = True  # train all layers
        if any(x in k for x in freeze):
            print(f"freezing {k}")
            v.requires_grad = False
            
    model.train(data="train\yoloBottleTrain.yaml", epochs=30, imgsz=640)
    model.save('modeloTreinado.pt')