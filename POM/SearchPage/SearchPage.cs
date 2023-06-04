using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace POM
{
    
    public class SearchPage : BasePage
    {

        #region Locator
        By clkLocation = By.Id("location");
        By clkHotels = By.Id("hotels");
        By clkRoomType = By.Id("room_type");
        By clkRoomNos = By.Id("room_nos");
        By txtDateIn = By.Id("datepick_in");
        By txtDateOut = By.Id("datepick_out");
        By clkAdultRoom = By.Id("adult_room");
        By clkChild = By.Id("child_room");
        By btnSubmit = By.Id("Submit");
        By btnReset = By.Id("Reset");

        #endregion
        public int location {get;set;}
        public int hotels { get; set; }
        public int roomType { get; set; }
        //public int roomNos { get; set; }
        public string roomNos { get; set; }
        public string dateIn { get; set; }
        public string dateOut { get; set; }
        public int adultRoom { get; set; }
        public int childRoom { get; set; }
        public void Search()
        {
            DropDown(clkLocation, location);
            DropDown(clkHotels, hotels);
            DropDown(clkRoomType, roomType);
            //DropDown(clkRoomNos, roomNos);
            DropDownByText(clkRoomNos, roomNos);

            Clear(txtDateIn);
            EnterText(txtDateIn, dateIn);
            Clear(txtDateOut);

            EnterText(txtDateOut, dateOut);
            DropDown(clkAdultRoom, adultRoom);
            DropDown(clkChild, childRoom);


            Click(btnSubmit);
        }
    }
}
