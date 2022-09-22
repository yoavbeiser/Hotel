using System;
using System.Collections.Generic;

namespace Hotel
{
    public class MinibarManager
    {
        #region Properties

        private readonly IList<IRefreshments> _itemsInMinibar;
        private double _bill;

        #endregion

        #region CTor

        public MinibarManager()
        {
            _itemsInMinibar = new List<IRefreshments>();
            _bill = 0.0;
        }

        #endregion

        #region Public

        public void AddSnack(Snack snack)
        {
            Add(snack);
        }

        public void AddDrink(Drink drink)
        {
            Add(drink);
        }

        public void ConsumeSnack(Snack snack)
        {
            Consume(snack);
        }

        public void ConsumeDrink(Drink drink)
        {
            Consume(drink);
        }

        public double Charge()
        {
            return _bill;
        }

        public void SetInitialBill(double bill)
        {
            _bill = bill;
        }

        #endregion

        #region Private

        private void Add(IRefreshments item)
        {
            _itemsInMinibar.Add(item);
        }

        private void Consume(IRefreshments item)
        {
            if (!_itemsInMinibar.Contains(item))
                throw new ItemNotFoundInMinibarException();

            _itemsInMinibar.Remove(item);
            _bill += item.Price;
        }

        #endregion
    }
}
