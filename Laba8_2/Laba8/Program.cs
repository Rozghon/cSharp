using System;
using System.Collections.Generic;

namespace Laba8
{
    class Telefone
    {
        public string className { get; set; }

        public int year { get; set; }
        public int numberOfButtons { get; set; }
        public int numberOfCameras { get; set; }
        public int megapixels { get; set; }

        public bool isHaveKeyboard { get; set; }
        public bool isHaveSensorScreen { get; set; }

    }

    class NewSmartPhone : Telefone
    {
        public Telefone smartPhone = new Telefone();

        public void Init()
        {
            smartPhone.className = "SmartPhone";
            smartPhone.year = 2018;
            smartPhone.numberOfButtons = 3;
            smartPhone.numberOfCameras = 5;
            smartPhone.megapixels = 108;
            smartPhone.isHaveKeyboard = false;
            smartPhone.isHaveSensorScreen = true;
        }

        public void Show()
        {
            Console.WriteLine(smartPhone.className);
            Console.WriteLine(smartPhone.year);
            Console.WriteLine(smartPhone.numberOfButtons);
            Console.WriteLine(smartPhone.numberOfCameras);
            Console.WriteLine(smartPhone.megapixels);
            Console.WriteLine(smartPhone.isHaveKeyboard);
            Console.WriteLine(smartPhone.isHaveSensorScreen);
        }
    }

    class SmartPhone : Telefone
    {
        public Telefone smartPhone = new Telefone();

        public void Init()
        {
            smartPhone.className = "SmartPhone";
            smartPhone.year = 2008;
            smartPhone.numberOfButtons = 4;
            smartPhone.numberOfCameras = 1;
            smartPhone.megapixels = 8;
            smartPhone.isHaveKeyboard = false;
            smartPhone.isHaveSensorScreen = true;
        }

        public void Show()
        {
            Console.WriteLine(smartPhone.className);
            Console.WriteLine(smartPhone.year);
            Console.WriteLine(smartPhone.numberOfButtons);
            Console.WriteLine(smartPhone.numberOfCameras);
            Console.WriteLine(smartPhone.megapixels);
            Console.WriteLine(smartPhone.isHaveKeyboard);
            Console.WriteLine(smartPhone.isHaveSensorScreen);
        }
    }

    class TelePhone : Telefone
    {
        public Telefone telePhone = new Telefone();

        public void Init()
        {
            telePhone.className = "TelePhone";
            telePhone.year = 1896;
            telePhone.numberOfButtons = 12;
            telePhone.numberOfCameras = 0;
            telePhone.megapixels = 0;
            telePhone.isHaveKeyboard = true;
            telePhone.isHaveSensorScreen = false;
        }

        public void Show()
        {
            Console.WriteLine(telePhone.className);
            Console.WriteLine(telePhone.year);
            Console.WriteLine(telePhone.numberOfButtons);
            Console.WriteLine(telePhone.numberOfCameras);
            Console.WriteLine(telePhone.megapixels);
            Console.WriteLine(telePhone.isHaveKeyboard);
            Console.WriteLine(telePhone.isHaveSensorScreen);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            NewSmartPhone newSmart = new NewSmartPhone();
            SmartPhone smart = new SmartPhone();
            TelePhone tele = new TelePhone();

            newSmart.Init();
            smart.Init();
            tele.Init();

            newSmart.Show();
            Console.WriteLine();
            smart.Show();
            Console.WriteLine();
            tele.Show();
        }
    }
}