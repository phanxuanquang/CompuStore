# CompuStore
Branch này dùng để tạo data sản phẩm.
## KHÔNG MERGE BRANCH NÀY
Quy trình:
1. tạo folder ./data
2. chạy file get_product_name.py
3. chạy file get_specs.py để lấy các file csv về 1 sản phẩm(1 file là 1 sản phẩm với các cấu hình khác nhau)
4. (Option) chạy file merge_đata.py để gộp các file csv thành 1 file lớn (làm màu là chính chứ to quá import DB cũng lag)

## lưu ý khi thay đổi số lượng process thực hiện:
trong các file python có biến là maxProcess. muốn nhanh thì tăng, muốn chậm thì giảm
Lưu ý: chạy quá nhanh có thể lúc ghi ra file bị lỗi hoặc thì bị Max entries request (kiểu bị chặn DDoS) => Lựa chọn số phù hợp
