using System;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace DDL
{
    public class DDL_GuiMail
    {
        private string senderEmail; 
        private string senderPassword; 

        public DDL_GuiMail(string senderEmail, string senderPassword)
        {
            this.senderEmail = senderEmail;
            this.senderPassword = senderPassword;
        }

        //Gửi mail cho nhân viên Gồm : [Nhân viên mới, nhân viên quên mật khẩu]
        public string SendMail(string recipientEmail, string taikhoan, string recipientPassword, bool isUpdate = false)
        {
            string thongbao;
            try
            {
                MailMessage mailMsg = new MailMessage();
                mailMsg.From = new MailAddress(senderEmail);
                mailMsg.To.Add(recipientEmail);
                if (isUpdate)
                {
                    mailMsg.Body = "Xin chào bạn, mật khẩu mới để truy cập phần mềm của bạn là: " + recipientPassword;
                    mailMsg.Subject = "Bạn đã yêu cầu cấp lại mật khẩu! Đừng quên nữa nhé....";

                    thongbao = "Mật khẩu mới đã được gửi đến: " + recipientEmail + " \n \t \t VUI LÒNG KIỂM TRA EMAIL!!!";
                }
                else
                {
                    mailMsg.Body = string.Format("Hi bạn, bạn đã được thêm vào danh sách trở thành nhân của phần mềm 'RESORT DU LỊCH' với " +
                                                 "thông tin đăng nhập là: \n- Tài khoản: {0} \n- Mật khẩu: {1} ", taikhoan, recipientPassword);
                    mailMsg.Subject = "HELLO BẠN, CHÀO MỪNG BẠN ĐẾN VỚI APP QUẢN LÝ DỊCH VỤ TẠI RESORT";

                    thongbao = "THÊM NHÂN VIÊN THÀNH CÔNG, VUI LÒNG KIỂM TRA EMAIL ĐỂ NHẬN TÀI KHOẢN.";
                }

                // Sử dụng phương thức SmtpClient
                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderEmail, "rmqjqtyqqiupjgjv");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mailMsg);
                }
                return thongbao;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //Gửi hóa đơn thanh toán vào mail khách hàng
        public string SendEmailWithAttachment(string recipientEmail, string tenkhachhang,  byte[] attachmentData, string attachmentName)
        {
            string thongbao;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);

                mail.Body = "HÓA ĐƠN THANH TOÁN DỊCH VỤ TẠI RESORT";
                mail.Subject = "Xin chào " + tenkhachhang +", vui lòng kiểm tra hóa đơn đính kèm.";
                thongbao = "HÓA ĐƠN THANH TOÁN ĐÃ ĐƯỢC GỬI QUA EMAIL: " + recipientEmail + " CỦA KHÁCH HÀNG: " + tenkhachhang;

                // Thêm file PDF như đính kèm trong email
                Attachment attachment = new Attachment(new MemoryStream(attachmentData), attachmentName);
                mail.Attachments.Add(attachment);

                // Sử dụng phương thức SmtpClien
                SmtpClient smtp = new SmtpClient()
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail, "rmqjqtyqqiupjgjv"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,

                };
                smtp.Send(mail);

                return thongbao;
            }

            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
