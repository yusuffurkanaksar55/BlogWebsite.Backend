using FluentValidation;
using PostSharp.Aspects;
using PowerBITurkeyBlog.Core.Validations.FluentValidations;

namespace PowerBITurkeyBlog.Core.Aspects.PostSharp
{
	[Serializable]
	public class FluentValidationAspect : OnMethodBoundaryAspect
	{
		Type _validator;

		public FluentValidationAspect(Type validator)
		{
			_validator = validator;
		}

		public override void OnEntry(MethodExecutionArgs args)
		{
			var validator = (IValidator)Activator.CreateInstance(_validator);
			var entityType = _validator.BaseType.GetGenericArguments()[0];
			var entities = args.Arguments.Where(t => t.GetType() == entityType);

			foreach (var entity in entities)
			{
				ValidatorTool.FluentValidate(validator, entity);
			}
		}
	}
}
