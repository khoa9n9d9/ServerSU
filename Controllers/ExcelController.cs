using OfficeOpenXml;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using OfficeOpenXml.Drawing;

namespace SUServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        [HttpGet(Name = "GetExcel")]
        public IActionResult Get()
        {
            var response = new { message = "haha-test-callapi" };
            return Ok(response);
        }
        [HttpPost("ExportExcel", Name = "ExportExcel")]
        public IActionResult ExportExcel([FromBody] List<string> items)
        {
            // Kiểm tra xem danh sách dữ liệu có rỗng hay không
            if (items == null || items.Count == 0)
            {
                return BadRequest("No data to export.");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Tạo một package Excel mới
            // Đường dẫn đến tệp Excel có sẵn
            string filePath = "Template/test.xlsx";

            // Mở tệp Excel
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Lấy worksheet đầu tiên
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // Đọc thông tin từ tệp Excel có sẵn
                int rowCount = 0;
                // Ghi thông tin mới vào tệp Excel
                worksheet.Cells[rowCount + 1, 1].Value = "New Data 1";
                worksheet.Cells[rowCount + 1, 2].Value = "New Data 2";

                // Lấy hình ảnh từ URL
                string imageUrl = "https://gw.alicdn.com/imgextra/i3/1737375601/O1CN019JVtNY1rFJBr51yZw_!!1737375601.jpg";
                System.Net.WebRequest request = System.Net.WebRequest.Create(imageUrl);
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream responseStream = response.GetResponseStream();
                Image img = Image.FromStream(responseStream);

                // Lưu hình ảnh vào một tệp tạm thời
                string tempImagePath = Path.GetTempFileName() + ".png";
                img.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Png);

                // Tạo đối tượng FileInfo từ tệp tạm thời
                FileInfo imageFile = new FileInfo(tempImagePath);
                // Lấy thời gian hiện tại
                DateTime now = DateTime.Now;

                // Tạo một chuỗi tên duy nhất dựa trên thời gian hiện tại
                string uniqueName = string.Format("Image_{0:D4}{1:D2}{2:D2}_{3:D2}{4:D2}{5:D2}",
                                                   now.Year, now.Month, now.Day,
                                                   now.Hour, now.Minute, now.Second);
                // Chèn hình ảnh vào tệp Excel
                ExcelPicture picture = worksheet.Drawings.AddPicture(uniqueName, imageFile);
                picture.SetPosition(5, 5);

                // Đặt kích thước cho hình ảnh
                picture.SetSize(100, 100);

                // Giả sử bạn muốn mỗi ô có kích thước tương đương với kích thước của hình ảnh
                double columnWidth = 30; // Đơn vị là độ
                double rowHeight = 20;   // Đơn vị là điểm

                // Đặt kích thước cho cột và hàng
                worksheet.Column(5).Width = columnWidth;
                worksheet.Row(5).Height = rowHeight;

                // Xuất ra tệp Excel kết quả
                MemoryStream stream = new MemoryStream(package.GetAsByteArray());
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "updated_data.xlsx");
            }
        }
    }
}
