public static class Ultilities
{
    // Logic
    public static RestaurantLogic restaurant = new RestaurantLogic("Restaurant");
    public static RestaurantInfoView restaurantInfo = new RestaurantInfoView();
    public static RestaurantInfoAdminView adminRestaurantInfo = new RestaurantInfoAdminView();
    public static UserRoleManager roleManager = new UserRoleManager();
    // Presentation
    public static RemoveReservationView removeReservation = new RemoveReservationView();
    public static ReservationMenuView reservationMenu = new ReservationMenuView();
    public static LoginView login = new LoginView();
    public static ManageEmployeesView manageEmployees = new ManageEmployeesView();
    public static MakeNewAccountView makeNewAccount = new MakeNewAccountView();
    public static FilterMenuView filterMenu = new FilterMenuView();
    
    // Future Menu
    public static FutureMenu futureMenu = new FutureMenu();

    public static CustomerResView cusResView = new CustomerResView();
}