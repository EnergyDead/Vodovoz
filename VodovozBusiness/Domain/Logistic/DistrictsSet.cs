using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using System.Linq;
using Gamma.Utilities;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using Vodovoz.Domain.Employees;
using Vodovoz.Domain.Sale;

namespace Vodovoz.Domain.Logistic
{
    [Appellative(Gender = GrammaticalGender.Masculine,
        NominativePlural = "наборы районов",
        Nominative = "набор районов")]
    [EntityPermission]
    public class DistrictsSet : PropertyChangedBase, IDomainObject, IValidatableObject, ICloneable
    {
        public virtual int Id { get; set; }

        private string name;
        [Display (Name = "Название набора районов")]
        public virtual string Name {
            get => name;
            set => SetField(ref name, value, () => Name);
        }
        
        private Employee author;
        [Display (Name = "Автор")]
        public virtual Employee Author {
            get => author;
            set => SetField(ref author, value, () => Author);
        }
        
        private DistrictsSetStatus status;
        [Display (Name = "Статус")]
        public virtual DistrictsSetStatus Status {
            get => status;
            set => SetField(ref status, value, () => Status);
        }
        
        private DateTime dateCreated;
        [Display (Name = "Время создания")]
        public virtual DateTime DateCreated {
            get => dateCreated;
            set => SetField(ref dateCreated, value, () => DateCreated);
        }
        
        private DateTime? dateActivated;
        [Display (Name = "Время активации")]
        public virtual DateTime? DateActivated {
            get => dateActivated;
            set => SetField(ref dateActivated, value, () => DateActivated);
        }
        
        private DateTime? dateClosed;
        [Display (Name = "Время закрытия")]
        public virtual DateTime? DateClosed {
            get => dateClosed;
            set => SetField(ref dateClosed, value, () => DateClosed);
        }
        
        private IList<District> districts = new List<District>();
        public virtual IList<District> Districts {
            get => districts;
            set => SetField(ref districts, value, () => Districts);
        }

        private GenericObservableList<District> observableDistricts;
        //FIXME Костыль пока не разберемся как научить hibernate работать с обновляемыми списками.
        public virtual GenericObservableList<District> ObservableDistricts =>
            observableDistricts ?? (observableDistricts = new GenericObservableList<District>(Districts));
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(String.IsNullOrWhiteSpace(Name)) {
                yield return new ValidationResult("Название набора должно быть обязательно заполнено",
                    new[] { this.GetPropertyName(x => x.Name) }
                );
            }
            if(Districts == null || !Districts.Any()) {
                yield return new ValidationResult("В наборе районов должен присутствовать хотя бы один район",
                    new[] { this.GetPropertyName(x => x.Districts) }
                );
            }
            if(Districts != null) {
                foreach (var district in Districts) {
                    foreach (var validationResult in district.Validate(validationContext)) {
                        yield return validationResult;
                    }
                }
            }
        }

        public virtual object Clone()
        {
            var newDistrictsSet = new DistrictsSet {
                Name = Name,
                Districts = new List<District>()
            };
            foreach (var district in Districts) {
                var newDistrict = district.Clone() as District;
                newDistrict.DistrictsSet = newDistrictsSet;
                newDistrictsSet.Districts.Add(newDistrict);
            }
            return newDistrictsSet;
        }
    }

    public enum DistrictsSetStatus
    {
        [Display(Name = "Черновик")]
        Draft,
        [Display(Name = "Активен")]
        Active,
        [Display(Name = "Закрыт")]
        Closed
    }
    
    public class DistrictsSetStatusStringType : NHibernate.Type.EnumStringType
    {
        public DistrictsSetStatusStringType() : base(typeof(DistrictsSetStatus))
        {
        }
    }
}