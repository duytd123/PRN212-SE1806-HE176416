using WPFApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp.Repository
{
    internal interface IRoomTypeRepository
    {
        void Add(RoomType roomType);
        void Update(RoomType roomType);
        RoomType GetById(int roomTypeId);
        IEnumerable<RoomType> GetAll();
    }
}
