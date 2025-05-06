using Microsoft.AspNetCore.SignalR;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }
        public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiverCategoryCount", value);

            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiverProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiverActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceiverPassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiverProductCountByCategoryNameHamburger", value5);

            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiverProductCountByCategoryNameDrink", value6);

            var value7 = _productService.TProductByAvgPrice().ToString("0.0") + " ₺";
            await Clients.All.SendAsync("ReceiverProductByAvgPrice", value7);

            var value8 = _productService.TProductCountByMaxPrice();
            await Clients.All.SendAsync("ReceiverProductCountByMaxPrice", value8);

            var value9 = _productService.TProductCountByMinPrice();
            await Clients.All.SendAsync("ReceiverProductCountByMinPrice", value9);

            var value10 = _productService.TProductAvgByHamburger().ToString("0.0") + " ₺";
            await Clients.All.SendAsync("ReceiverProductAvgByHamburger", value10);


            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiverTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiverActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice().ToString("0.0") + " ₺";
            await Clients.All.SendAsync("ReceiverLastOrderPrice", value13);

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount().ToString("0.0") + " ₺";
            await Clients.All.SendAsync("ReceiverTotalMoneyCaseAmount", value14);

            var value15 = _orderService.TTodayTotalPrice().ToString("0.0") + " ₺";
            await Clients.All.SendAsync("TodayTotalPrice", value15);

            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("MenuTableCount", value16);
        }

        public async Task SendProgressBar()
        {
            var value1 = _moneyCaseService.TTotalMoneyCaseAmount().ToString("0.00" + " ₺");
            await Clients.All.SendAsync("TotalMoneyCaseAmount", value1);

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("TActiveOrderCount", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("TMenuTableCount", value3);

            var value4 = _productService.TProductByAvgPrice().ToString("0.00");
            await Clients.All.SendAsync("TProductByAvgPrice",decimal.Parse( value4));

            var value5 = _productService.TProductAvgByHamburger().ToString("0.00");
            await Clients.All.SendAsync("TProductAvgByHamburger", decimal.Parse(value5));

            var value6 = _productService.TProductCountByCategoryNameDrink().ToString("0.00");
            await Clients.All.SendAsync("TProductCountByCategoryNameDrink", decimal.Parse(value6));

            var value7 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("TTotalOrderCount", value7);

            var value8 = _productService.TProductBySteakBurgerPrice();
            await Clients.All.SendAsync("TProductBySteakBurgerPrice", value8);

            var value9 = _productService.TProductTotalByDrinkPrice();
            await Clients.All.SendAsync("TProductTotalByDrinkPrice", value9);

            var value10 = _productService.TProductByTotalSaladPrice();
            await Clients.All.SendAsync("TProductByTotalSaladPrice", value10);

            var value11 = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("TCategoryCount", value11);

            var value12 = _productService.TProductCount();
            await Clients.All.SendAsync("TProductCount", value12);

            var value13 = _bookingService.TBookingStatusApprovedCount();
            await Clients.All.SendAsync("TBookingStatusApprovedCount", value13);

            var value14 = _productService.TProductTotalPrice();
            await Clients.All.SendAsync("TProductTotalPrice", value14);

            var value15 = _productService.TProductByAvgPrice().ToString("0.00");
            await Clients.All.SendAsync("TProductByAvgPrice", value15);

            var value16 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("TLastOrderPrice", value16);


        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetAll();
            await Clients.All.SendAsync("ReceiverBookingList", values);

            
            var values1 = _bookingService.TBookingStatusApprovedList();
            await Clients.All.SendAsync("BookingStatusApprovedlist",values1);

            var values2 = _bookingService.TBookingStatusCanselledList();
            await Clients.All.SendAsync("BookingStatusCanselledList", values2);

            var values3 = _bookingService.TBookingStatusPendingApproval();
            await Clients.All.SendAsync("BookingStatusPendingApproval", values3);

            var values4 = _bookingService.TBookingStatusApprovedCount();
            await Clients.All.SendAsync("BookingStatusApprovedCount", values4);

            var values5 = _bookingService.TBookingStatusCanselledCount();
            await Clients.All.SendAsync("BookingStatusCanselledCount", values5);

            var values6 = _bookingService.TBookingStatusPendingApprovalCount();
            await Clients.All.SendAsync("BookingStatusPendingApprovalCount", values6);

        }
        public async Task SendNotification()
        {
            var values = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiverNotificationCountByStatusFalse", values);

            var notificationGetList = _notificationService.TGetAllNotificationByFalse();
            await Clients.All.SendAsync("ReceiverNotificationByFalse",notificationGetList);
        }
        public async Task GetMenuTableByStatus()
        {
            var value= _menuTableService.TGetAll();
            await Clients.All.SendAsync("ReceiverMenuTableByStatus",value);
        }
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiverMessage",user,message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiverClientCount",clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiverClientCount",clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
