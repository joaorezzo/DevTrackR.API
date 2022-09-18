using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTrackR.API.Entities
{
    public class Package
    {
    public Package(string title, decimal weight)
    {
      Code = Guid.NewGuid().ToString();
      Title = title;
      Weight = weight;
      Delivered = false;
      PostedAt = DateTime.Now;
      Updates = new List<PackageUpdate>();
    }


        public void AddUpdate(string status, bool delivered){
          

            if (Delivered) {
                throw new Exception("Package is already delivered");
            }
            var update = new PackageUpdate(status, Id);
            Updates.Add(update);
            Delivered = delivered;
        }


        public int Id { get; private set; } //encapsulamento, nao deixar que outras classes atualizem o Id. Atualizar = set
        public string Code { get; private set; }
        public string Title { get; private set; } //titulo
        public decimal Weight { get; private set; } //peso
        public bool Delivered { get; private set; } // Entregue?
        public DateTime PostedAt { get; private set; }
        public List <PackageUpdate> Updates {get; private set; } //lista com atualizacoes da entidade PackageUpdate
    }
}