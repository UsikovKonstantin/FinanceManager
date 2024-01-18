using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Application.Exceptions;
using FinanceManager.Application.Features.Users.Shared;
using FinanceManager.Application.Models.Identity;
using FinanceManager.Domain;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Options;

namespace FinanceManager.Application.Features.Users.Commands.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Unit>
{
	private readonly IUserRepository _userRepository;
	private readonly JwtSettings _jwtSettings;

	public ResetPasswordCommandHandler(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
	{
		_userRepository = userRepository;
		_jwtSettings = jwtSettings.Value;
	}

	public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
	{
		ResetPasswordCommandValidator validator = new ResetPasswordCommandValidator();
		ValidationResult validationResult = await validator.ValidateAsync(request, cancellationToken);
		if (!validationResult.IsValid)
			throw new BadRequestException("Invalid ResetPasswordRequest", validationResult);

		User? user = await _userRepository.FirstOrDefaultAsync(u => u.ResetPasswordToken == request.Token);
		if (user == null)
			throw new NotFoundException(nameof(User), request.Token);
		if (user.ResetPasswordTokenExpirationDate < DateTime.UtcNow)
			throw new BadRequestException("ResetPasswordTokenExpirationDate has already expired");
		if (user.ResetPasswordTokenExpirationDate < DateTime.UtcNow)
			throw new BadRequestException("ResetPasswordTokenExpirationDate has already expired");
		if (SecretHasher.Verify(request.Password, user.Password))
			throw new BadRequestException("Password must be new");

		user.Password = SecretHasher.Hash(request.Password);
		user.ResetPasswordToken = null;
		user.ResetPasswordTokenExpirationDate = null;
		await _userRepository.UpdateAsync(user);

		return Unit.Value;
	}
}
