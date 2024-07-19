using HNNewsAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNNewsAPI.Services.Interfaces
{
    public interface IStoryService
    {
       Task<List<StoryModel>> GetStories();
    }
}
