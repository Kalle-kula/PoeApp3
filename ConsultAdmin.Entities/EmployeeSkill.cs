using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultAdmin.Entities
{
    public class EmployeeSkill : BaseModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int Level { get; set; }
        public string Comment { get; set; }
        public DateTime LastUpdate { get; set; }

        //public bool AreaImgUpClicked { get; set; }
        //public bool AreaImgDownClicked { get; set; }
        //public bool SubAreaImgUp { get; set; }
        public bool SubAreaTextVisible { get; set; }
        //public bool SubAreaImgDown { get; set; }
        private bool _areaImgDownClicked;
        private bool _areaImgUpClicked;
        private bool _subAreaImgDown;
        private bool _subAreaImgUp;
        public bool AreaImgDownClicked
        {
            get { return _areaImgDownClicked; }
            set
            {
                if (_areaImgDownClicked != value)
                {
                    SetPropertyField(nameof(AreaImgDownClicked), ref _areaImgDownClicked, value);
                }
            }
        }

        public bool AreaImgUpClicked
        {
            get { return _areaImgUpClicked; }
            set
            {
                if (_areaImgUpClicked != value)
                {
                    SetPropertyField(nameof(AreaImgUpClicked), ref _areaImgUpClicked, value);
                }
            }
        }

        public bool SubAreaImgDown
        {
            get { return _subAreaImgDown; }
            set
            {
                if (_subAreaImgDown != value)
                {
                    SetPropertyField(nameof(SubAreaImgDown), ref _subAreaImgDown, value);
                }
            }
        }

        public bool SubAreaImgUp
        {
            get { return _subAreaImgUp; }
            set
            {
                if (_subAreaImgUp != value)
                {
                    SetPropertyField(nameof(SubAreaImgUp), ref _subAreaImgUp, value);
                }
            }
        }
    }
}
