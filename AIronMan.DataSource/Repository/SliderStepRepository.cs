using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIronMan.Domain;

namespace AIronMan.DataSource {
    public class SliderStepRepository : Repository<SliderStep>, ISliderStepRepository {
        public SliderStepRepository(DB context) : base(context) { }
    }
}
