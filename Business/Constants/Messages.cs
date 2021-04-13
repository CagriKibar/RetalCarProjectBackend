using Core.Utilities.Security.JWT;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductUpdated="Araba Güncellendi";
        public static string ProductDeleted = "Araba Silindi";
        public static string FailedUpdate = "Güncelleme de hata oluştu";
        public static string ProductNameInValid = "Ürün İsmi Geçersiz";
        public static bool ProductListed;
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi";

        public static string ImgaesLimitError = "En fazla beş adet Resim eklenebilir.";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string PasswordError = "Şifre Hatalı";

        public static string SucccesfulLogin = "Sisteme Giriş Başarılı";

        public static string UserAlreadyExists = "Bu kullanıcı mevcut";

        public static string UserRegistered = "Kayıt olundu";

        public static string  AccessTokenCreated="Access Token Oluşturuldu";

        public static string ColorAdded = "Renk Eklendi";

        public static string ColorDeleted = "Renk Silindi";

        public static string ColorUpdated = "Renk Güncellendi";

        public static string DeletedCarImage = "Araba Resmi silindi";

        public static string UserAdded = "Kullanıcı Eklendi";

        public static string UserDeleted = "Kullanıcı silindi";

        public static string UserListed = "Kullanıcı Listelendi";

        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string CarImageAdded = "Araç Resmi Eklendi";

        public static string AuthorizationDenied = "yetki reddedildi";
        public static string Listed = "Listelendi!";
        public static string Added = "Eklendi!";
        public static string Updated = "Güncellendi!";
        public static string Deleted = "Silindi!";
        public static string NotListed = "Listeleme Yapılamadı";
        public static string NotAdded = "Ekleme Yapılamadı";
        public static string NotUpdated = "Güncelleme Yapılamadı";
        public static string NotDeleted = "Silme İşlemi Yapılamadı";
        public static string NameInvalid = "Geçersiz İsim";
       // public static string MaintenanceTime = "Bakım Zamanı";
        public static string InvalidEntry = "Geçersiz Giriş";
        public static string NotAvailable = "Mevcut Değil";
        public static string InvalidExtension = "Geçersiz Resim Formatı";

        //Araç Logo Mesajları
        public static string BrandListed = "Markalar Listelendi!";
        public static string logoLimitExceeded = "Markkanın 1 Logosu olabilir";
        public static string BrandImageAdded = "Marka Logosu Eklendi";
        public static string BrandImageUpdated = "Marka Logosu Güncellendi";
        public static string BrandImageDeleted = "Marka Logosu Silindi";
        //Araç Logo Mesajları
        public static string CarsListed = "Araçlar Listelendi!";
        public static string CarImageLimitExceeded = "Araç Resim Sınırı Aşıldı";
        public static string CarsImageAdded = "Araç Resmi Eklendi";
        public static string CarsImageUpdated = "Araç Resmi Güncellendi";
        public static string CarsImageDeleted = "Araç Resmi Silindi";
        // Doğrulama Mesajları
        public static string WrongValidationType = "Yanlış Doğrulama Türü";
        public static string CanNotBeBlank = "Boş Bırakılamaz";
        public static string InvalidEmailAddress = "Geçersiz E-Mail Formatı";



        ////Güvenlik Mesajları
        //public static string AuthorizationDenied = "Yetkin Yok";
        //public static string UserNotFound = "Kullanıcı Bulunamadı";
        //public static string PasswordError = "Şifre Hatalı";
        //public static string SuccessfulLogin = "Giriş Başarılı";
        //public static string UserAlreadyExists = "Bu Kullanıcı Zaten Mevcut";
        //public static string UserRegistered = "Kullanıcı Başarılı Bir Şekilde Kaydoldu";
        //public static string AccessTokenCreated = "Token Oluşturuldu ";
    }
}
