using Domain.Abstructions;
using Domain.Entities;
using Domain.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BeneficiaryFeatures.Commands
{
    /// <summary>
    /// This Will Call When AddBeneficiary API Occcured
    /// Handle All Business Logic here, related to Add Beneficiary into system
    /// </summary>
    public class AddBeneficiaryHandler : IRequestHandler<AddBeneficiaryCommand, ResponseViewModel>
    {
        /// <summary>
        /// unit Of Work single use to perform single Execution point of save changes.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="_unitOfWork"></param>
        /// <param name="mapper"></param>
        public AddBeneficiaryHandler(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        /// <summary>
        /// handler Process
        /// </summary>
        /// <param name="addBeneficiary"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ResponseViewModel> Handle(AddBeneficiaryCommand addBeneficiary, CancellationToken cancellationToken)
        {
            var response = new ResponseViewModel();

            //Get All Users Beneficiaries to verify the added limit
            var beneficiarList = await unitOfWork.BeneficiaryRepository.GetUserBeneficiaries(addBeneficiary.requestModel.UserID, true);

            if (beneficiarList.Any() && beneficiarList.Count >= 5)
            {
                response.Message = "Not Added! User Can add maximum only 5 beneficiaries, User limit Exceeded";
                return response;
            }

            //verify if user already have beneficiary with same Name and mobile number
            var isbeneficiaryExist = beneficiarList.Any(x => x.NickName == addBeneficiary.requestModel.NickName
                                                             && x.MobileNumber == addBeneficiary.requestModel.MobileNumber);
            if (isbeneficiaryExist)
            {
                response.Message = "Beneficiary Already Exist.";
                return response;
            }

            //Insert New Beneficiary
            var _addBeneficiary = new Beneficiary(addBeneficiary.requestModel.NickName,
                                                 addBeneficiary.requestModel.MobileNumber,
                                                 addBeneficiary.requestModel.UserID, true);

            await unitOfWork.BeneficiaryRepository.AddAsync(_addBeneficiary);


            //Persist All SaveChanges
            var saved = await unitOfWork.ApplySaveChanges(cancellationToken);
            if (saved > 0)
            {
                response.Message = $"{addBeneficiary.requestModel.NickName} - Beneficiary Added Sucessfully";
                response.IsSucess = true;
            }

            return response;
        }
    }
}
