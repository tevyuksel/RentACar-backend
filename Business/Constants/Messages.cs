using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi!";
        public static string CarDeleted = "Araba silindi!";
        public static string CarUpdated = "Araba güncellendi!";
        public static string CarNameInValid = "Araba ismi geçersiz!";
        public static string MaintenanceTime = "Bakımdayız!";
        public static string CarsListed = "Arabalar listendi!";
        public static string BrandsListed = "Markalar listelendi!";
        public static string BrandAdded = "Marka eklendi!";
        public static string BrandDeleted = "Marka silindi!";
        public static string BrandUpdated = "Marka güncellendi!";
        public static string ColorsListed = "Renkler listelendi!";
        public static string ColorAdded = "Renk eklendi!";
        public static string ColorDeleted = "Renk silindi!";
        public static string ColorUpdated = "Renk güncellendi!";
        public static string UserAdded = "Kullanıcı eklendi!";
        public static string UserDeleted = "Kullanıcı silindi!";
        public static string UserUpdated = "Kullanıcı güncellendi!";
        public static string UserNameInValid = "Kullanıcı ismi geçersiz!";
        public static string UsersListed = "Kullanıcılar listendi!";
        public static string CustomersListed = "Kullanıcılar listelendi!";
        public static string CustomerAdded = "Kullanıcı eklendi!";
        public static string CustomerDeleted = "Kullanıcı silindi!";
        public static string CustomerUpdated = "Kullanıcı güncellendi!";
        public static string CarImagesListed = "Araba resimleri listeledi!";
        public static string CarImageImageLimitError= "En fazla 5 resim ekleyebilirsiniz!";
        public static string CarImageExistsError = "Araba resmi ekleyin!";
        public static string CarImageAdded = "Araba resmi eklendi!";
        public static string CarImageUpdated = "Araba resmi güncellendi!";

        public static string AuthorizationDenied = "Yetkin yok dayı!";
        public static string UserRegistered = "Kayıt oldu!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Parola hatası!";
        public static string SuccessfulLogin = "Başarılı giriş!";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
        public static string AccessTokenCreated = "Token oluşturuldu!";

        public static string RentalCheckIsCarReturnError = "Araç şuanda kiralanmış durumda, lütfen başka bir araç seçiniz!";
        public static string RentalCheckRentalExistsError = "Geçerli bir işlem değil!";
    }
}
