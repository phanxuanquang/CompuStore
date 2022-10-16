import os

listFile = os.listdir('./data')
data = []
for file in listFile:
        lines = open(f'./data/{file}', 'r', encoding='utf-8').readlines()
        for product in lines[1:]:
                data.append(product)

open('./all_data.csv', 'a', encoding='utf-8').write('STT,Serial máy,Dòng sản phẩm,Nhà sản xuất,Xuất xứ,Mã màn hình,Độ phân giải,Kích thước màn hình,Độ sáng,Tấm nền,Độ phủ màu,Tần số quét,Cảm ứng,Loại màn hình,Tỉ lệ màn hình,CPU,iGPU,RAM,Loại ổ cứng,Dung lượng ổ cứng,GPU,Dung lượng pin,Cân nặng,Tên sản phẩm,Năm ra mắt,Chất liệu vỏ,Cổng kết nối,Webcam,Kích thước máy tính,Hệ điều hành,Wifi,Bluetooth,Đơn giá,Mã màu,Tên màu' + '\n')
for product in data:
        open('./all_data.csv', 'a', encoding='utf-8').write(product)