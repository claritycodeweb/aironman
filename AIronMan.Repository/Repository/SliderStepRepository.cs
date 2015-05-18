using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AIronMan.DataSource;
using AIronMan.Domain;

namespace AIronMan.Repository {
    public class SliderStepRepository : Repository<SliderStep>, ISliderStepRepository {
        public SliderStepRepository(DB context) : base(context) { }
    }
}
