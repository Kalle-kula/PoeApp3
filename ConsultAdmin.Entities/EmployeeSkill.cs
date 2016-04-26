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

        
        private bool _areaImgDownClicked;
        private bool _areaImgUpClicked;
        private bool _typeNameImgDown;
        private bool _typeNameImgUp;
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

        public bool TypeNameImgDown
        {
            get { return _typeNameImgDown; }
            set
            {
                if (_typeNameImgDown != value)
                {
                    SetPropertyField(nameof(TypeNameImgDown), ref _typeNameImgDown, value);
                }
            }
        }

        public bool TypeNameImgUp
        {
            get { return _typeNameImgUp; }
            set
            {
                if (_typeNameImgUp != value)
                {
                    SetPropertyField(nameof(TypeNameImgUp), ref _typeNameImgUp, value);
                }
            }
        }
    }
}
