using MaterializedView.Data;
using MaterializedView.Domain.Entities;
using MaterializedView.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MaterializedView.Application.EventHandlers
{
    public class OrderStartedEventHandler : INotificationHandler<OrderStartedEvent>
    {
        private readonly WriteDbContext _writeDbContext;
        private readonly ReadDbContext _readDbContext;

        public OrderStartedEventHandler(WriteDbContext writeDbContext, ReadDbContext readDbContext)
        {
            this._writeDbContext = writeDbContext;
            this._readDbContext = readDbContext;
        }
        public async Task Handle(OrderStartedEvent notification, CancellationToken cancellationToken)
        {
            var order = _writeDbContext.Orders.First(x => x.Id == notification.OrderId);
            var orderItems = order.OrderItems
              .GroupBy(x => x.Product)
              .Select(x => new
              {
                  CustomerName = _writeDbContext.Customers.First(c => c.Id == order.CustomerId).Name,
                  ProductName = x.Key,
                  ProductCount = x.Sum(x => x.Amount),
                  TotalSold = x.Sum(x => x.Total)
              })
              .ToList();
            List<OrderMaterializedView> orderMaterializedViews = new List<OrderMaterializedView>();
            foreach (var (item, result) in from item in orderItems
                                           let result = _readDbContext.OrderMaterializedView.FirstOrDefault(x => x.ProductName == item.ProductName && x.CustomerName == item.CustomerName)
                                           select (item, result))
            {
                if (result != null)
                {
                    result.ProductCount += item.ProductCount;
                    result.TotalSold += item.TotalSold;
                    _readDbContext.SaveChanges();
                }
                else
                {
                    orderMaterializedViews.Add(new OrderMaterializedView
                    {
                        CustomerName = item.CustomerName,
                        ProductName = item.ProductName,
                        ProductCount = item.ProductCount,
                        TotalSold = item.TotalSold,
                    });
                }
            }

            _readDbContext.OrderMaterializedView.AddRange(orderMaterializedViews);
            await _readDbContext.SaveChangesAsync();

        }

        
    }
}
