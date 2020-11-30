using System;

namespace Laba11
{
    public class Computer
    {
        public bool isReinstalledWindows = false;
        public bool isChangeVideocard = false;
        public bool isChangeMotherboard = false;
        public bool isChangePowerBlock = false;
        public bool isAddMemory = false;
        public bool isConfiguredPrograms = false;
    }

    public class ServiceCenter
    {
        public Computer computer = new Computer();

        public void ReinstallWindows()
        {
            computer.isReinstalledWindows = true;
        }

        public void ChangeVideocard()
        {
            computer.isChangeVideocard = true;
        }

        public void ChangeMotherboard()
        {
            computer.isChangeMotherboard = true;
        }

        public void ChangePowerBlock()
        {
            computer.isChangePowerBlock = true;
        }

        public void AddMemory()
        {
            computer.isAddMemory = true;
        }

        public void ConfiguratePrograms()
        {
            computer.isConfiguredPrograms = true;
        }

        public void Show()
        {
            Console.WriteLine("isReinstalledWindows: {0}", computer.isReinstalledWindows);
            Console.WriteLine("isChangeVideocard: {0}", computer.isChangeVideocard);
            Console.WriteLine("isChangeMotherboard: {0}", computer.isChangeMotherboard);
            Console.WriteLine("isChangePowerBlock: {0}", computer.isChangePowerBlock);
            Console.WriteLine("isAddMemory: {0}", computer.isAddMemory);
            Console.WriteLine("isConfiguredPrograms: {0}", computer.isConfiguredPrograms);
            Console.WriteLine();
        }
    }

    class Program
    {
        delegate void ReinstalledWindowsDelegate();
        delegate void ChangeVideocardDelegate();
        delegate void ChangeMotherboardDelegate();
        delegate void ChangePowerBlockDelegate();
        delegate void AddMemoryDelegate();
        delegate void ConfigurateProgramsDelegate();

        static void Main(string[] args)
        {
            ServiceCenter serviceCenter = new ServiceCenter();

            ReinstalledWindowsDelegate reinstalledWindows = serviceCenter.ReinstallWindows;
            ChangeVideocardDelegate changeVideocard = serviceCenter.ChangeVideocard;
            ChangeMotherboardDelegate changeMotherboard = serviceCenter.ChangeMotherboard;
            ChangePowerBlockDelegate changePowerBlock = serviceCenter.ChangePowerBlock;
            AddMemoryDelegate addMemory = serviceCenter.AddMemory;
            ConfigurateProgramsDelegate configuratePrograms = serviceCenter.ConfiguratePrograms;

            serviceCenter.Show();

            reinstalledWindows();
            changeMotherboard();
            addMemory();
            configuratePrograms();

            serviceCenter.Show();
        }
    }
}
