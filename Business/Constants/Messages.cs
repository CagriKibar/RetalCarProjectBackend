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
    }
}
