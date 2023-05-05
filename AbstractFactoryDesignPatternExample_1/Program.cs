﻿

ComputerCreator computerCreator = new ComputerCreator();
Computer asus = computerCreator.CreateComputer(ComputerType.Asus);
Computer toshiba = computerCreator.CreateComputer(ComputerType.Toshiba);
Computer monster = computerCreator.CreateComputer(ComputerType.Monster);


class Computer
{
    public CPU CPU { get; set; }
    public RAM RAM { get; set; }
    public VideoCard VideoCard { get; set; }

    public Computer(CPU cPU, RAM rAM, VideoCard videoCard)
    {
        CPU = cPU;
        RAM = rAM;
        VideoCard = videoCard;
    }
}


#region Abstract Products
interface ICPU
{

}

interface IRAM
{

}

interface IVideoCard
{

}
#endregion

#region Concrete Products
class CPU : ICPU
{
    public CPU(string text)
    {
        Console.WriteLine(text);
    }
}

class RAM : IRAM
{
    public RAM(string text)
    {
        Console.WriteLine(text);
    }

}

class VideoCard : IVideoCard
{
    public VideoCard(string text)
    {
        Console.Write(text);
    }
}
#endregion

#region Abstract Factory
interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}
#endregion

#region Concrete Factory

class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU()
    {
        return new CPU("Asus CPU has been Created !");
    }

    public IRAM CreateRAM()
    {
        return new RAM("Asus RAM has been Created !");
    }

    public IVideoCard CreateVideoCard()
    {
        return new VideoCard("Asus VideCard has been Created !");
    }
}

class ToshibaFactory : IComputerFactory
{
    public ICPU CreateCPU()
    {
        return new CPU("Toshiba CPU has been Created !");
    }

    public IRAM CreateRAM()
    {
        return new RAM("Toshiba RAM has been Created !");
    }

    public IVideoCard CreateVideoCard()
    {
        return new VideoCard("Toshiba VideCard has been Created !");
    }
}

class MonsterFactory : IComputerFactory
{
    public ICPU CreateCPU()
    {
        return new CPU("Monster CPU has been Created !");
    }

    public IRAM CreateRAM()
    {
        return new RAM("Monster RAM has been Created !");
    }

    public IVideoCard CreateVideoCard()
    {
        return new VideoCard("Monster VideCard has been Created !");
    }
}
#endregion

#region Computer Creator

enum ComputerType
{
    Asus, Toshiba, Monster,
}
class ComputerCreator
{
    private IRAM _ram;
    private ICPU _cpu;
    private IVideoCard _videoCard;
  
    public Computer CreateComputer(ComputerType computerType)
    {
        IComputerFactory computerFactory = null;
        switch (computerType)
        {
            case ComputerType.Asus:
                 computerFactory = new AsusFactory();            
                break;
            case ComputerType.Toshiba:
                 computerFactory = new ToshibaFactory();            
                break;
            case ComputerType.Monster:
                 computerFactory = new MonsterFactory();      
                break;
            default:
                break;
        }

        _ram = computerFactory.CreateRAM();
        _cpu = computerFactory.CreateCPU();
        _videoCard = computerFactory.CreateVideoCard();

        return new Computer(_cpu as CPU, _ram as RAM, _videoCard as VideoCard);
    }
}
#endregion