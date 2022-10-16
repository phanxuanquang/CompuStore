import json
import os
import random
import string
from time import sleep
import requests
import re
import multiprocessing

queryOption = "?m="

def getLinkQueryOption(linkProduct:str, cpu = 0, ram = 0, gpu = 0, battery = 0, display = 0, storageCapacity = 0):
    return f'{linkProduct}{queryOption}b.{battery}_c.{cpu}_d.{display}_g.{gpu}_r.{ram}_s.{storageCapacity}'

def getHTML(linkProduct:str):
    respones = requests.get(linkProduct, allow_redirects = True)

    if respones.status_code == 200:
        return {"url" : respones.url, "content" : respones.content.decode('utf-8').split('\n')}
    return None

def getOptionSpecs(content: str):
    map = {}
    startSpecs = False
    for index in range(len(content)):
        if not startSpecs and 'Tests and Specifications' in content[index]:
            startSpecs = True
        elif startSpecs:
            if 'name="first_d"' in content[index]:
                if "Display" in map:
                    map["Display"] = map["Display"] + 1
                else:
                    map["Display"] = 1
            elif 'name="first_b"' in content[index]:
                if "Battery" in map:
                    map["Battery"] = map["Battery"] + 1
                else:
                    map["Battery"] = 1
            elif 'name="first_c"' in content[index]:
                if "CPU" in map:
                    map["CPU"] = map["CPU"] + 1
                else:
                    map["CPU"] = 1
            elif 'name="first_g"' in content[index]:
                if "GPU" in map:
                    map["GPU"] = map["GPU"] + 1
                else:
                    map["GPU"] = 1
            elif 'name="first_r"' in content[index]:
                if "RAM" in map:
                    map["RAM"] = map["RAM"] + 1
                else:
                    map["RAM"] = 1
            elif 'name="first_s"' in content[index]:
                if "Storage capacity" in map:
                    map["Storage capacity"] = map["Storage capacity"] + 1
                else:
                    map["Storage capacity"] = 1
            elif 'Comparison with competitors' in content[index]:
                break
    return map

def getSpecs(content: str):
    map = {}
    startSpecs = False
    startPorts = False
    for index in range(len(content)):
        if not startSpecs:
            if 'Tests and Specifications' in content[index]:
                startSpecs = True
            elif 'Launched:' in content[index]:
                launched = content[index]
                launched = re.search('Launched:</strong>(.*)</li><li class="mb"><strong>S', launched)
                map["Date release"] = launched.group(1).split(' ')[-1]
        elif startSpecs:
            if startPorts:
                if "cell-h" in content[index]:
                    typePort = content[index]
                    quantityPort = content[index + 1]
                    typePort = re.search('class="cell-h">(.*)</td>', typePort)
                    quantityPort = re.search('class="cell-s">(.*)</td>', quantityPort)
                    typePort = typePort.group(1)
                    quantityPort = quantityPort.group(1)
                    if "No" in quantityPort:
                        continue
                    elif "Yes" in quantityPort:
                        map["Ports"][typePort] = 1
                    else:
                        map["Ports"][typePort] = quantityPort
                elif '</table>' in content[index]:
                    startPorts = False
            elif 'Weight' in content[index]:
                weight = content[index + 1]
                weight = re.search('class="cell-s">(.*)</td>', weight)
                map["Weight"] = weight.group(1).split(' ')[0]
            elif 'Dimensions' in content[index]:
                dimensions = content[index + 1]
                dimensions = re.search('class="cell-s">(.*) mm <br>', dimensions)
                map["Dimensions"] = dimensions.group(1)
            elif 'Colors' in content[index]:
                color = content[index + 1]
                color = re.search('class="cell-s">(.*)</td>', color)
                map["Colors"] = color.group(1).split(', ')
            elif 'Size' in content[index] and "Size display" not in map:
                sizeDisplay = content[index + 1]
                sizeDisplay = re.search('class="cell-s">(.*)</td>', sizeDisplay)
                map["Size display"] = sizeDisplay.group(1).split(' ')[0]
            elif 'Type' in content[index] and 'Type panel' not in map:
                typeDisplay = content[index + 1]
                typeDisplay = re.search('class="cell-s">(.*)</td>', typeDisplay)
                map["Type panel"] = typeDisplay.group(1)
            elif 'Refresh rate' in content[index]:
                rr = content[index + 1]
                rr = re.search('class="cell-s">(.*)</td>', rr)
                map["Refresh rate"] = rr.group(1).split(' ')[0]
            elif 'Aspect ratio' in content[index]:
                ratio = content[index + 1]
                ratio = re.search('class="cell-s">(.*)</td>', ratio)
                map["Aspect ratio"] = ratio.group(1)
            elif 'Resolution' in content[index]:
                resolution = content[index + 1]
                resolution = re.search('class="cell-s">(.*)</td>', resolution)
                map["Resolution"] = ''.join(resolution.group(1).split(' ')[0 : 3])
            elif 'Touchscreen' in content[index]:
                touchscreen = content[index + 1]
                touchscreen = re.search('class="cell-s">(.*)</td>', touchscreen)
                map["Touchscreen"] = touchscreen.group(1) == "Yes"
            elif 'Coating' in content[index]:
                coating = content[index + 1]
                coating = re.search('class="cell-s">(.*)</td>', coating)
                map["Coating"] = coating.group(1)
            elif 'DCI-P3 color gamut' in content[index] or 'sRGB color space' in content[index] or 'Adobe RGB profile' in content[index]:
                colorSpace = content[index]
                valueColorSpace = content[index + 1]
                colorSpace = re.search('class="cell-h">(.*)</td>', colorSpace)
                valueColorSpace = re.search('class="cell-s">(.*)</td>', valueColorSpace)
                if "Color space" in map:
                    map["Color space"].append({
                        "Name color space": colorSpace.group(1), 
                        "Value color space": valueColorSpace.group(1)})
                else:
                    map["Color space"] = [{
                        "Name color space": colorSpace.group(1), 
                        "Value color space": valueColorSpace.group(1)}]
            elif 'Max. brightness' in content[index]:
                brightness = content[index + 4]
                brightness = re.search('<span class="score-bar-result-number">(.*)</span>', brightness)
                map["Brightness"] = brightness.group(1).split(' ')[0]
            elif 'name="first_b"' in content[index] and 'checked' in content[index]:
                battery = content[index + 2]
                battery = re.search('<span>(.*)</span>', battery)
                map["Battery"] = battery.group(1).split(' ')[0]
            elif 'name="first_c"' in content[index] and 'checked' in content[index]:
                cpu = content[index + 2]
                cpu = re.search('<span>(.*)</span>', cpu)
                map["CPU"] = cpu.group(1)
            elif 'Integrated GPU' in content[index]:
                iGPU = content[index + 1]
                iGPU = re.search('class="cell-s">(.*)</td>', iGPU)
                map["iGPU"] = iGPU.group(1)
            elif 'name="first_g"' in content[index] and 'checked' in content[index]:
                gpu = content[index + 2]
                gpu = re.search('<span>(.*)</span>', gpu)
                map["GPU"] = gpu.group(1)
            elif 'name="first_r"' in content[index] and 'checked' in content[index]:
                ram = content[index + 2]
                ram = re.search('<span>(.*)</span>', ram)
                map["RAM"] = ram.group(1)
            elif 'name="first_s"' in content[index] and 'checked' in content[index]:
                storage = content[index + 2]
                storage = re.search('<span>(.*)</span>', storage)
                map["Storage capacity"] = storage.group(1)
            elif 'Storage type' in content[index]:
                typeStorage = content[index + 1]
                typeStorage = re.search('class="cell-s">(.*)</td>', typeStorage)
                map["Storage type"] = typeStorage.group(1)
            elif 'Wi-Fi standard' in content[index]:
                wifi = content[index + 1]
                wifi = re.search('class="cell-s">(.*)</td>', wifi)
                map["Wi-Fi standard"] = wifi.group(1)
            elif 'Bluetooth' in content[index]:
                bluetooth = content[index + 1]
                bluetooth = re.search('class="cell-s">(.*)</td>', bluetooth)
                map["Bluetooth"] = bluetooth.group(1)
            elif 'Webcam resolution' in content[index]:
                webcam = content[index + 1]
                webcam = re.search('class="cell-s">(.*)</td>', webcam)
                map["Webcam resolution"] = webcam.group(1)
            elif 'Ports' in content[index]:
                startPorts = True
                map["Ports"] = {}
            elif 'Comparison with competitors' in content[index]:
                break
    if "iGPU" in map and "GPU" in map:
        if map["iGPU"] == map["GPU"]:
            del map["GPU"]
    return map

mapManufacture = {
  "apple": {
    "Country": "US",
    "Material": [
      "Aluminium"
    ]
  },
  "dell": {
    "Country": "US",
    "Material": [
      "Carbon fiber"
    ]
  },
  "eluktronics": {
    "Country": "US",
    "Material": [
      "Magnesium",
      "Aluminium"
    ]
  },
  "lenovo": {
    "Country": "China",
    "Material": [
      "Magnesium",
      "Aluminium"
    ]
  },
  "acer": {
    "Country": "Taiwan",
    "Material": [
      "Plastic",
      "Aluminium"
    ]
  },
  "hp": {
    "Country": "US",
    "Material": [
      "Aluminium"
    ]
  },
  "asus": {
    "Country": "Taiwan",
    "Material": [
      "Plastic",
      "Aluminium"
    ]
  },
  "gigabyte": {
    "Country": "China",
    "Material": [
      "Aluminium"
    ]
  },
  "honor": {
    "Country": "China",
    "Material": [
      "Aluminium"
    ]
  },
  "huawei": {
    "Country": "China",
    "Material": [
      "Aluminium"
    ]
  },
  "lg": {
    "Country": "Korea",
    "Material": [
      "Aluminium"
    ]
  },
  "samsung": {
    "Country": "Korea",
    "Material": [
      "Aluminium",
      "Magnesium"
    ]
  },
  "microsoft": {
    "Country": "US",
    "Material": [
      "Aluminium"
    ]
  },
  "msi": {
    "Country": "Taiwan",
    "Material": [
      "Plastic",
      "Aluminium"
    ]
  },
  "razer": {
    "Country": "US",
    "Material": [
      "Aluminium"
    ]
  },
  "XMG": {
    "Country": "Germany",
    "Material": [
      "Aluminium"
    ]
  }
}

mapColor = {
  "black": "#000000",
  "gray": "#808080",
  "white": "#ffffff",
  "silver": "#c0c0c0",
  "blue": "#0000ff",
  "gold": "#ffd700",
  "pink": "#ffc0cb",
  "green": "#008000",
  "red": "#ff0000",
  "purple": "#a020f0",
  "burgundy": "#800020",
  "yellow": "#ffff00",
  "orange": "#ffa500"
}

def updateProperty(map:dict, nameProduct:str, indexRandom:int):
    price = random.randrange(10000000, 100000000, step = 100000)
    result = {"Price" : price}
    result["Name"] = nameProduct
    split = nameProduct.split(' ')
    if "CPU" in map:
        if 'i7' in map["CPU"]:
            result["OS"] = 'Windows 11 Pro 64bit'
        else:
            result["OS"] = "Windows 11 Home 64bit"
    else:
        result["OS"] = "Linux"
    if 'Apple' in nameProduct:
        result["OS"] = "MacOS"
    result["Manufacturer"] = split[0]
    result["Country"] = mapManufacture[split[0].lower()]["Country"]
    lineup = None
    for index in range(len(split)):
        if len(split[index]) > 0:
            if split[index][0].isdigit():
                lineup = ' '.join(split[0 : index])
                break
    result["Lineup"] = lineup
    if len(mapManufacture[split[0].lower()]["Material"]) > 1:
        result["Body material"] = mapManufacture[split[0].lower()]["Material"][indexRandom]
    else:
        result["Body material"] = mapManufacture[split[0].lower()]["Material"][0]
    result["Colors"] = []
    if "Colors" in map:
        for color in map["Colors"]:
            colorCode = mapColor[color.lower()]
            result["Colors"].append({"Color code": colorCode, "Color name":color})
    else:
        result["Colors"] = [{"Color code": mapColor["black"], "Color name": "Black"}]
    return result

def json4csv(product:dict):
    colorSpace = None
    if "Color space" in product:
        for color in product["Color space"]:
            if colorSpace == None:
                colorSpace = f'{color["Name color space"]}:{color["Value color space"]}'
            else:
               colorSpace += f'-{color["Name color space"]}:{color["Value color space"]}' 
    codeDisplay = f'DP-{product.get("Resolution", "")}-{product.get("Size display", "")}-{product.get("Brightness", "")}-{product.get("Type panel", "")}-{colorSpace}-{product.get("Refresh rate", "")}-{product.get("Touchscreen", "")}-{product.get("Coating", "")}-{product.get("Aspect ratio", "")}'
    ports = None
    if "Ports" in product:
        for key in product["Ports"]:
            if ports == None:
                ports = f'{key}:{product["Ports"][key]}'
            else:
               ports += f'_{key}:{product["Ports"][key]}'
    touchscreen = product.get("Touchscreen", None)
    if touchscreen == None or touchscreen == False:
        touchscreen = 0
    else:
        touchscreen = 1
    result = []
    for color in product["Colors"]:
        serial = ''.join(random.sample(string.ascii_letters + string.digits, 16)).upper()
        result.append(f'{serial}\t{product.get("Lineup", "")}\t{product.get("Manufacturer", "")}\t{product.get("Country", "")}\t{codeDisplay}\t{product.get("Resolution", "")}\t{product.get("Size display", "")}\t{product.get("Brightness", "")}\t{product.get("Type panel", "")}\t{colorSpace or ""}\t{product.get("Refresh rate", "")}\t{touchscreen}\t{product.get("Coating", "")}\t{product.get("Aspect ratio", "")}\t{product.get("CPU", "")}\t{product.get("iGPU", "")}\t{product.get("RAM", "")}\t{product.get("Storage type", "")}\t{product.get("Storage capacity", "")}\t{product.get("GPU", "")}\t{product.get("Battery", "")}\t{product.get("Weight", "")}\t{product.get("Name", "")}\t{product.get("Date release", "")}\t{product.get("Body material", "")}\t{ports or ""}\t{product.get("Webcam resolution", "")}\t{product.get("Dimensions", "")}\t{product.get("OS", "")}\t{product.get("Wi-Fi standard", "")}\t{product.get("Bluetooth", "")}\t{product.get("Price", "")}\t{color["Color code"]}\t{color["Color name"]}')
    return result

def getPathFile(nameProduct:str):
    name = nameProduct.replace('\\', '-')
    name = name.replace('/','-')
    name = name.replace('<','-')
    name = name.replace('>','-')
    name = name.replace('*','-')
    name = name.replace('"','-')
    name = name.replace('|','-')
    return './data/' + name + '.tsv'

def process(nameProduct:str, linkProduct:str):
    try:
        map = []
        data = []
        content = getHTML(linkProduct)
        options = getOptionSpecs(content["content"])
        randomNumber = random.randint(0, 1)
        index = 1
        open(getPathFile(nameProduct), 'a', encoding='utf-8').write('STT\tSerial máy\tDòng sản phẩm\tNhà sản xuất\tXuất xứ\tMã màn hình\tĐộ phân giải\tKích thước màn hình\tĐộ sáng\tTấm nền\tĐộ phủ màu\tTần số quét\tCảm ứng\tLoại màn hình\tTỉ lệ màn hình\tCPU\tiGPU\tRAM\tLoại ổ cứng\tDung lượng ổ cứng\tGPU\tDung lượng pin\tCân nặng\tTên sản phẩm\tNăm ra mắt\tChất liệu vỏ\tCổng kết nối\tWebcam\tKích thước máy tính\tHệ điều hành\tWifi\tBluetooth\tĐơn giá\tMã màu\tTên màu' + '\n')
        for cpu in range(1, options["CPU"] + 1):
            for gpu in range(1, options["GPU"] + 1):
                for ram in range(1, options["RAM"] + 1):
                    for display in range(1, options["Display"] + 1):
                        for storage in range(1, options["Storage capacity"] + 1):
                            for battery in range(1, options["Battery"] + 1):
                                currentOption = getHTML(getLinkQueryOption(linkProduct, cpu, ram, gpu, battery, display, storage))
                                if currentOption["url"] not in map:
                                    map.append(currentOption["url"])
                                    specs = getSpecs(currentOption["content"])
                                    specs.update(updateProperty(specs, nameProduct, randomNumber))
                                    data.append(specs)
                                    products = json4csv(specs)
                                    for item in products:
                                        open(getPathFile(nameProduct), 'a', encoding='utf-8').write(f'{index}\t{item}' + '\n')
                                        index += 1
        
        # open(f'./{nameProduct}.json', 'a', encoding='utf-8').write(json.dumps(data))
        # index = 1
        # open(getPathFile(nameProduct), 'a', encoding='utf-8').write('STT, Serial máy, Dòng sản phẩm, Nhà sản xuất, Xuất xứ, Mã màn hình, Độ phân giải, Kích thước màn hình, Độ sáng, Tấm nền, Độ phủ màu, Tần số quét, Cảm ứng, Loại màn hình, Tỉ lệ màn hình, CPU, iGPU, RAM, Loại ổ cứng, Dung lượng ổ cứng, GPU, Dung lượng pin, Cân nặng, Tên sản phẩm, Năm ra mắt, Chất liệu vỏ, Cổng kết nối, Webcam, Kích thước máy tính, Hệ điều hành, Wifi, Bluetooth, Đơn giá, Mã màu, Tên màu' + '\n')
        # for product in data:
        #     products = json4csv(product)
        #     for item in products:
        #         open(getPathFile(nameProduct), 'a', encoding='utf-8').write(f'{index},{item}' + '\n')
        #         index += 1

        del map
        del data
        del content
        del options
    except:
        os.remove(getPathFile(nameProduct))
        open('./error.csv', 'a', encoding='utf-8').write(f'{nameProduct};;;{linkProduct}' + '\n')

if __name__ == '__main__':
    file = open('./data.csv', 'r', encoding='utf-8')
    products = file.readlines()
    listProcess = []
    for product in products:
        product = product.replace('\n', '')
        split = product.split(';;;')
        listProcess.append(multiprocessing.Process(target = process, kwargs = {"nameProduct": split[0], "linkProduct": split[1]}))

    index = 0
    maxProcess = 16
    lengthProcess = len(listProcess)

    while index < lengthProcess:
        while len(multiprocessing.active_children()) < maxProcess and index < lengthProcess:
            listProcess[index].start()
            index += 1
        sleep(2)

    while len(multiprocessing.active_children()) != 0:
        sleep(2)