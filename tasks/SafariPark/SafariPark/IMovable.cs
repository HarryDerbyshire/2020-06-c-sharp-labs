using System;
using System.Collections.Generic;
using System.Text;

namespace SafariPark
{
    public interface IMovable
    {
        string Move();

        string Move(int times);
     
    }
}
