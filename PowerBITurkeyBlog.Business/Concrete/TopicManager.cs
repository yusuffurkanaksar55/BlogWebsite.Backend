using PowerBITurkeyBlog.Business.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Abstract;
using PowerBITurkeyBlog.Core.Utilites.Results.Concrete;
using PowerBITurkeyBlog.DataAccess.Abstract;
using PowerBITurkeyBlog.DataAccess.Concrete.EntityFramework;
using PowerBITurkeyBlog.Entities.Entities;

namespace PowerBITurkeyBlog.Business.Concrete
{
	public class TopicManager : ITopicService
	{
		private readonly ITopicDal _topicDal;

		public TopicManager(ITopicDal topicDal)
		{
			_topicDal = topicDal;
		}

		public IDataResult<List<Topic>> GetAll()
		{
			return new SuccessDataResult<List<Topic>>(_topicDal.GetAll().ToList(),"Topics Listed");
		}

		public async Task<IDataResult<Topic?>> GetEntityById(int id)
		{
			if (id==null)
			{
				return new ErrorDataResults<Topic?>("Id Parameter not found");
			}

			var topic = await _topicDal.GetByIdAsync(id);
			return new SuccessDataResult<Topic?>(topic, "Topic Founded");
		}

		public IResult AddEntity(Topic entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Topic not found");
			}

			_topicDal.AddAsync(entity);
			return new SuccessResult(true, "Topic Added");
		}

		public IResult AddEntityRange(IEnumerable<Topic> entities)
		{
			if (entities == null)
			{
				return new ErrorResult(false, "Topics not found");
			}

			var topic = _topicDal.AddRangeAsync(entities);
			return new SuccessResult(true, "Topics Added");
		}

		public IResult DeleteEntity(int id)
		{
			if (id == null)
			{
				return new ErrorResult(false, "Id parameter is not found");
			}

			var topic = _topicDal.Where(x => x.TopicId == id).SingleOrDefault();
			_topicDal.Remove(topic);
			return new SuccessResult(true, "Topic Deleted");
		}

		public IResult DeleteEntity(Topic entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Topic not found");
			}
			_topicDal.Remove(entity);
			return new SuccessResult(true, "Topic Deleted");
		}

		public IResult Update(Topic entity)
		{
			if (entity == null)
			{
				return new ErrorResult(false, "Topic not found");
			}
			_topicDal.Update(entity);
			return new SuccessResult(true, "Topic Updated");
		}

		public IResult AnyAsync(int id)
		{
			if (id == null)
			{
				return new ErrorResult(false, "Id Parameter is empty");
			}

			return new Result(_topicDal.AnyAsync(x => x.TopicId == id).Result, $"{nameof(Topic)} Not Found");
		}
	}
}
