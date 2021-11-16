﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Bindings.Collections.Generic;
using QS.DomainModel.Entity;
using QS.DomainModel.Entity.EntityPermissions;
using QS.HistoryLog;
using Vodovoz.Domain.Goods;

namespace Vodovoz.Domain.Orders
{
	[Appellative(Gender = GrammaticalGender.Neuter,
		NominativePlural = "основания скидок",
		Nominative = "основание скидки")]
	[EntityPermission]
	[HistoryTrace]
	public class DiscountReason : PropertyChangedBase, IDomainObject, IValidatableObject
	{
		private const int _zero = 0;
		private const int _percentsLimit = 100;
		private const int _nameLimit = 45;
		private string _name;
		private bool _isArchive;
		private bool _isPremiumDiscount;
		private DiscountUnits _valueType;
		private decimal _value;
		private IList<ProductGroup> _productGroups = new List<ProductGroup>();
		private GenericObservableList<ProductGroup> _observableProductGroups;

		public virtual int Id { get; set; }

		[Display(Name = "Название")]
		public virtual string Name
		{
			get => _name;
			set => SetField(ref _name, value);
		}

		[Display(Name = "В архиве")]
		public virtual bool IsArchive
		{
			get => _isArchive;
			set => SetField(ref _isArchive, value);
		}

		[Display(Name = "Тип значения скидки")]
		public virtual DiscountUnits ValueType
		{
			get => _valueType;
			set => SetField(ref _valueType, value);
		}

		[Display(Name = "Значение скидки")]
		public virtual decimal Value
		{
			get => _value;
			set => SetField(ref _value, value);
		}
		
		[Display(Name = "Премиальная скидка?")]
		public virtual bool IsPremiumDiscount
		{
			get => _isPremiumDiscount;
			set => SetField(ref _isPremiumDiscount, value);
		}

		public virtual IList<ProductGroup> ProductGroups
		{
			get => _productGroups;
			set => SetField(ref _productGroups, value);
		}

		//FIXME Кослыль пока не разберемся как научить hibernate работать с обновляемыми списками.
		public virtual GenericObservableList<ProductGroup> ObservableProductGroups =>
			_observableProductGroups ??
			(_observableProductGroups = new GenericObservableList<ProductGroup>(ProductGroups));

		public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if(Id == _zero && IsArchive)
			{
				yield return new ValidationResult("Нельзя создать новое архивное основание", new[] { nameof(IsArchive) });
			}
			if(string.IsNullOrEmpty(Name))
			{
				yield return new ValidationResult("Название должно быть заполнено", new[] { nameof(Name) });
			}
			if(Name?.Length > _nameLimit)
			{
				yield return new ValidationResult($"Превышена длина названия ({Name.Length}/{_nameLimit})", new[] { nameof(Name) });
			}
			if(Value == _zero)
			{
				yield return new ValidationResult($"Размер скидки не может быть равен {_zero}", new[] { nameof(Value) });
			}
			if(ValueType == DiscountUnits.percent && Value > _percentsLimit)
			{
				yield return new ValidationResult($"Размер скидки в процентах больше {_percentsLimit}", new[] { nameof(Value) });
			}
			if(ProductGroups.Count == _zero)
			{
				yield return new ValidationResult($"Необходимо добавить хотя бы одну товарную группу",
					new[] { nameof(ProductGroups.Count) });
			}
		}

		public virtual void AddProductGroup(ProductGroup productGroup)
		{
			if(!ObservableProductGroups.Contains(productGroup))
			{
				ObservableProductGroups.Add(productGroup);
			}
		}

		public virtual void RemoveProductGroup(ProductGroup productGroup)
		{
			if(ObservableProductGroups.Contains(productGroup))
			{
				ObservableProductGroups.Remove(productGroup);
			}
		}
	}

	public class DiscountUnitTypeStringType : NHibernate.Type.EnumStringType
	{
		public DiscountUnitTypeStringType() : base(typeof(DiscountUnits)) { }
	}
}
