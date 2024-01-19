using FinanceManager.Application.Contracts.Identity;
using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Auth.Shared;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;

namespace FinanceManager.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly IUserService _userService;

	public ChangePasswordCommandHandler(IUserRepository userRepository, IUserService userService)
	{
		_userRepository = userRepository;
		_userService = userService;
	}

	public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
	{
		ChangePasswordCommandValidator validator = new ChangePasswordCommandValidator();
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid ChangePasswordRequest", validationResult);

		User? user = await _userRepository.GetByIdAsync(_userService.UserId);
		if (user == null)
			throw new NotFoundException(nameof(User), _userService.UserId);
		if (!SecretHasher.Verify(request.CurrentPassword, user.Password))
			throw new BadRequestException("Incorrect password");

		user.Password = SecretHasher.Hash(request.NewPassword);
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
