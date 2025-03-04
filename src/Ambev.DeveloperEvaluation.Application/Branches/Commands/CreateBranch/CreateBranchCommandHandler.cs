using Ambev.DeveloperEvaluation.Domain.Models;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branchs.Commands.CreateBranch;

public class CreateBranchCommandHandler(IBranchRepository branchRepository, IMapper mapper) : IRequestHandler<CreateBranchCommand, CreateBranchResult>
{
    public async Task<CreateBranchResult> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var newBranch = await branchRepository.CreateAsync(mapper.Map<Branch>(command), cancellationToken);

        return mapper.Map<CreateBranchResult>(newBranch);
    }
}
