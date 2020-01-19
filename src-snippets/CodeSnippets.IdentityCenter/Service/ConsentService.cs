using CodeSnippets.IdentityCenter.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.IdentityCenter.Service
{
    public class ConsentService
    {
        private readonly IClientStore _clientStore;
        private readonly IResourceStore _resourceStore;
        private readonly IIdentityServerInteractionService _identityServerInteractionService;
        public ConsentService(IClientStore clientStore, IResourceStore resourceStore, IIdentityServerInteractionService identityServerInteractionService)
        {
            _clientStore = clientStore;
            _resourceStore = resourceStore;
            _identityServerInteractionService = identityServerInteractionService;
        }

        public async Task<ConsentViewModel> BuildConsentViewModelAsync(string returnUrl, ConsentInputModel model = null)
        {
            var request = await _identityServerInteractionService.GetAuthorizationContextAsync(returnUrl);

            if (returnUrl == null)
                return null;

            var client = await _clientStore.FindEnabledClientByIdAsync(request.ClientId);
            var resources = await _resourceStore.FindEnabledResourcesByScopeAsync(request.ScopesRequested);

            var vm = CreateConsentViewModel(request, client, resources, model);
            vm.ReturnUrl = returnUrl;

            return vm;
        }

        private ConsentViewModel CreateConsentViewModel(AuthorizationRequest request, Client client, Resources resources, ConsentInputModel model)
        {
            var vm = new ConsentViewModel
            {
                ClientName = client.ClientName ?? client.ClientId,
                ClientLogoUrl = client.LogoUri,
                ClientUrl = client.ClientUri,
                AllowRememberConsent = client.AllowRememberConsent,
                RememberConsent = model?.RememberConsent ?? true,
                ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>(),
            };

            vm.IdentityScopes = resources.IdentityResources.Select(i => CreateScopeViewModel(i, vm.ScopesConsented.Contains(i.Name) || model == null));
            vm.ResourceScopes = resources.ApiResources.SelectMany(a => a.Scopes).Select(s => CreateScopeViewModel(s, vm.ScopesConsented.Contains(s.Name) || model == null));

            return vm;
        }

        private ScopeViewModel CreateScopeViewModel(IdentityResource identityResource, bool check)
        {
            return new ScopeViewModel
            {
                Name = identityResource.Name,
                DisplayName = identityResource.DisplayName,
                Description = identityResource.Description,
                Emphasize = identityResource.Emphasize,
                Checked = check || identityResource.Required,
                Required = identityResource.Required
            };
        }
        private ScopeViewModel CreateScopeViewModel(Scope scope, bool check)
        {
            return new ScopeViewModel
            {
                Name = scope.Name,
                DisplayName = scope.DisplayName,
                Description = scope.Description,
                Emphasize = scope.Emphasize,
                Checked = check || scope.Required,
                Required = scope.Required
            };
        }

        public async Task<ProcessConsentResult> ProcessConsentAsync(ConsentInputModel model)
        {
            ConsentResponse grantedConsent = null;
            var result = new ProcessConsentResult();
            if (model?.Button == "no")
            {
                grantedConsent = ConsentResponse.Denied;
            }
            else if (model?.Button == "yes")
            {
                if (model.ScopesConsented != null && model.ScopesConsented.Any())
                {
                    grantedConsent = new ConsentResponse
                    {
                        RememberConsent = model.RememberConsent,
                        ScopesConsented = model.ScopesConsented
                    };
                }
                result.ValidationError = "至少选中一个权限";
            }

            if (grantedConsent != null)
            {
                var request = await _identityServerInteractionService.GetAuthorizationContextAsync(model.ReturnUrl);
                await _identityServerInteractionService.GrantConsentAsync(request, grantedConsent);

                result.RedirectUrl = model.ReturnUrl;
            }
            else
            {
                var consentVideModel = await BuildConsentViewModelAsync(model.ReturnUrl, model);
                result.ViewModel = consentVideModel;
            }
            return result;
        }
    }
}
