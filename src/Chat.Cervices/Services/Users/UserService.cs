﻿using Chat.Application.Exceptions.Users;
using Chat.DataAccess.Interfaces.Users;
using Chat.DataAccess.ViewModels.Users;
using Chat.Persistence.Dtos.Users;
using Chat.Persistence.Helpers;
using Chat.Services.Interfaces.Auth;
using Chat.Services.Interfaces.Common;
using Chat.Services.Interfaces.Users;

namespace Chat.Services.Services.Users;

public class UserService : IUserService
{
    private readonly IIdentityService _identity;
    private readonly IUserRepository _repository;
    private readonly IFileService _fileService;

    public UserService(IUserRepository userRepository,
        IFileService fileService
        , IIdentityService identity)
    {
        this._repository = userRepository;
        this._fileService = fileService;
        this._identity = identity;
    }

    public async Task<IList<UserViewModel>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        return users;
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var user = await _repository.GetByIdAsync(_identity.Id);
        if (user == null) throw new UserNotFoundException();
        else return user;
    }

    public async Task<bool> UpdateAsync(long userId, string phone, UserUpdateDto dto)

    {
        var user = await _repository.GetByPhoneAsync(phone);
        if (user is null) throw new UserNotFoundException();

        // update user with new items 
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;

        if (dto.Avatar is not null)
        {
            // delete old avatar
            //if (user.ImagePath != "avatars\\avatar.png" && user.ImagePath != "Avatars\\avatar.png")
            //{
            var deleteResult = await _fileService.DeleteAvatarAsync(user.Avatar);
            //    if (deleteResult is false) throw new ImageNotFoundException();
            //}

            // upload new avatar
            string newImagePath = await _fileService.UploadAvatarAsync(dto.Avatar);

            // parse new path to avatar
            user.Avatar = newImagePath;
        }
        // else user old avatar is have to save

        var checkPhone = await _repository.GetByPhoneAsync(dto.PhoneNumber);
        //if (checkPhone is null || user.PhoneNumber == dto.PhoneNumber)
        //{
        //    user.PhoneNumber = dto.PhoneNumber;
        //}
        //else throw new UserAlreadyExistsException(dto.PhoneNumber);
        user.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(userId, user);

        return dbResult > 0;
    }
}
