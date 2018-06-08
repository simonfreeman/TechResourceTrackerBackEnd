using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechResourceService
{
    public interface IRssReader
    {
        RssFeed ParseFeed();
    }
}
