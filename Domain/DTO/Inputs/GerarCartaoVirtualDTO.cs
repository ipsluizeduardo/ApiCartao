using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.DTO.Inputs
{
    public class GerarCartaoVirtualDTO : Notifiable
    {
        public string? Email {get; set;}

        public void Validar() {
            AddNotifications(new Contract().IsEmail(Email,"Email", "Email Inválido"));
        }

    }
}