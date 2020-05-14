using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DAL.Abstract
{
    public  interface IHotelRepo
    {
       Task<List<Hotel>> GetAllHotels();

        Task<Hotel> GetHotelById(int id);

        Task<Hotel> GetHotelByName(string name);

        Task<Hotel> CreateHotel(Hotel hotel);

        Task<Hotel> UpdateHotel(Hotel hotel);

        Task DeleteHotel(int id);

    }
}
