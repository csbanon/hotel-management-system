using System;
using System.Linq;

namespace OleHotels.Models
{
    public interface ICardRepository 
    {
        Card Create(Card newCard);
    }
    public class CardRepository : ICardRepository
    {
        private readonly OleHotelsDbContext _context;

        public CardRepository()
        {
            _context = new OleHotelsDbContext();
        }
        public Card Create(Card newCard)
        {
            _context.Cards.Add(newCard);
            _context.SaveChanges();
            return newCard;
        }
    }
}