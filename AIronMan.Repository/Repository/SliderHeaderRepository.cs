using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class SliderHeaderRepostiory : Repository<SliderHeader>, ISliderHeaderRepository {
        public SliderHeaderRepostiory(DB context) : base(context) { }
    }
}
