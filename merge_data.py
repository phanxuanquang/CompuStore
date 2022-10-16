import os

listFile = os.listdir('./data')
data = []
for file in listFile:
        lines = open(f'./data/{file}', 'r', encoding='utf-8').readlines()
        for product in lines[1:]:
                data.append(product)

open('./all_data.tsv', 'a', encoding='utf-8').write('STT\tSerial máy\tDòng sản phẩm\tNhà sản xuất\tXuất xứ\tMã màn hình\tĐộ phân giải\tKích thước màn hình\tĐộ sáng\tTấm nền\tĐộ phủ màu\tTần số quét\tCảm ứng\tLoại màn hình\tTỉ lệ màn hình\tCPU\tiGPU\tRAM\tLoại ổ cứng\tDung lượng ổ cứng\tGPU\tDung lượng pin\tCân nặng\tTên sản phẩm\tNăm ra mắt\tChất liệu vỏ\tCổng kết nối\tWebcam\tKích thước máy tính\tHệ điều hành\tWifi\tBluetooth\tĐơn giá\tMã màu\tTên màu' + '\n')
for product in data:
        open('./all_data.tsv', 'a', encoding='utf-8').write(product)