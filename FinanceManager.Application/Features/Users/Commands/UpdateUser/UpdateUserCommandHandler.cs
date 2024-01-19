using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

	public UpdateUserCommandHandler(IUserRepository userRepository, IUserService userService)
	{
		_userRepository = userRepository;
		_userService = userService;
	}

	public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		UpdateUserCommandValidator validator = new UpdateUserCommandValidator();
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid UpdateUserRequest", validationResult);

		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);

		user.FirstName = request.FirstName ?? user.FirstName;
		user.LastName = request.LastName ?? user.LastName;
		user.Gender = request.Gender ?? user.Gender;
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
