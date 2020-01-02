using IdentityModel;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeSnippets.IdentityCenter
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser{SubjectId = "818727", Username = "张三", Password = "123456",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "张三"),
                    new Claim(JwtClaimTypes.GivenName, "三"),
                    new Claim(JwtClaimTypes.FamilyName, "张"),
                    new Claim(JwtClaimTypes.Email, "zhangsan@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://zhangsan.com"),
                    new Claim(JwtClaimTypes.Address, @"{ '城市': '杭州', '邮政编码': '310000' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new TestUser{SubjectId = "88421113", Username = "李四", Password = "654321",
                Claims =
                {
                    new Claim(JwtClaimTypes.Name, "李四"),
                    new Claim(JwtClaimTypes.GivenName, "四"),
                    new Claim(JwtClaimTypes.FamilyName, "李"),
                    new Claim(JwtClaimTypes.Email, "lisi@email.com"),
                    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim(JwtClaimTypes.Address, @"{ '城市': '上海', '邮政编码': '200000' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new Claim("location", "somewhere")
                }
            }
        };
    }
}
