using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Send_message_SMTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //для отправки писем SMTP нужно на самом почтовом ящике майл разрешить доступ сторонним приложениям
            //безопасность->внешние сервисы->доступ к почте включить
            //затем нужно создать пароль для сторонних приложений и использовать его для отправки, а не пароль от почтового ящика!
            Console.WriteLine("Введите ваш электронный адрес: ");
            string addressfrom = Console.ReadLine();
            Console.WriteLine("Введите ваш пароль: ");
            string password = Console.ReadLine();
            Console.WriteLine("Введите адрес электронной почты получателя: ");
            string addressto = Console.ReadLine();
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(addressfrom);
            // кому отправляем
            MailAddress to = new MailAddress(addressto);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "Тест";
            // текст письма
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(addressfrom, password);
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
        }
    }
}
