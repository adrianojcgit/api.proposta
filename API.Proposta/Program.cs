using API.Proposta.Application.Dto;
using API.Proposta.Application.Interfaces;
using API.Proposta.Application.Services;
using API.Proposta.Domain.Entities;
using API.Proposta.Domain.Interfaces;
using API.Proposta.Infra.Data.Repositories;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<PropostaBaseDto, PropostaBase>().ReverseMap();
    cfg.CreateMap<PropostaDto, Proposta>().ReverseMap();
    cfg.CreateMap<FaturamentoDto, Faturamento>().ReverseMap();
    cfg.CreateMap<EnderecoDto, Endereco>().ReverseMap();
    cfg.CreateMap<ContaBancoDto, ContaBanco>().ReverseMap();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProposta, PropostaService>();
builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
//var corsPolicy = "MinhaPoliticaCORS";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "MinhaPoliticaCORS",
//                      policy =>
//                      {
//                          policy.WithOrigins("https://localhost:7232/");
//                      });
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseRouting();
app.UseHttpsRedirection();
//app.UseCors(corsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
