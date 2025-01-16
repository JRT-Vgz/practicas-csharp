// See https://aka.ms/new-console-template for more information
using DesignPattern;
using DesignPattern._1_Singleton;
using DesignPattern._2_FactoryMethod;
using DesignPattern._3_DependencyInjection;
using DesignPattern._4_RepositoryPattern;
using DesignPattern._5_UnitOfWork;
using DesignPattern._6_StrategyPattern;
using DesignPattern._7_BuilderPattern;
using DesignPattern._8_StatePattern;
using DesignPattern.Models;

Console.WriteLine("--- PATRONES DE DISEÑO ---");

// SINGLETON
//var log = Log.Instance;
//log.Save("Guardando linea de log con un log singleton.");


// FACTORY METHOD
//SaleFactory storeSaleFactory = new StoreSaleFactory(10);
//SaleFactory internetSaleFactory = new InternetSaleFactory(2);

//ISale sale1 = storeSaleFactory.GetSale();
//sale1.Sell(15);

//ISale sale2 = internetSaleFactory.GetSale();
//sale2.Sell(15);


// DEPENDENCY INJECTION
//var beer = new Beer("Pikantus", "Erginger");
//var drinkWithBeer = new DrinkWithBeer(beer, 1, 10);
//drinkWithBeer.Build();


// REPOSITORY
//using (var context = new DesignPatternsContext())
//{
//    var beerRepository = new Repository<DesignPattern.Models.Beer>(context);

//    var beer = new DesignPattern.Models.Beer() { Name = "Fuller", Style = "Strong Ale" };
//    beerRepository.Add(beer);
//    beerRepository.Save();
//}


// UNIT OF WORK
//using (var context = new DesignPatternsContext())
//{
//    var unitOfWork = new UnitOfWork(context);

//    var beerRepository = unitOfWork.Beers;
//    var beer = new DesignPattern.Models.Beer() { Name = "Tyris", Style = "IPA" };
//    beerRepository.Add(beer);

//    var brandRepository = unitOfWork.Brands;
//    var brand = new DesignPattern.Models.Brand() { Name = "Fuller" };
//    brandRepository.Add(brand);

//    unitOfWork.Save();
//}


// STRATEGY
//var context = new Context(new CarStrategy());
//context.Run();

//context.Strategy = new MotorbikeStrategy();
//context.Run();


// BUILDER
//var builder = new PreparedAlcoholDrinkConcreteBuilder();
//var barmanDirector = new BarmanDirector(builder);

//barmanDirector.PrepareMargarita();
//var preparedDrink = builder.GetPreparedDrink();

//Console.WriteLine(preparedDrink.Result);


// STATE
//var customerContext = new CustomerContext();
//Console.WriteLine(customerContext.GetState());

//customerContext.Request(100);
//Console.WriteLine(customerContext.GetState());

//customerContext.Request(50);
//Console.WriteLine(customerContext.GetState());

//customerContext.Request(100);
//Console.WriteLine(customerContext.GetState());

//customerContext.Request(50);
//Console.WriteLine(customerContext.GetState());

//customerContext.Request(50);