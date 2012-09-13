using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CursusIndex.data_logic;

namespace CursusIndex.data_logic
{
    public static class DaoFactory
    {
        public static UmbracoDaoFactory GetUmbracoDaoFactory()
        {
            return new UmbracoDaoFactory();
        }
    }
}