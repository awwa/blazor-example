using System.Reflection;
using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class CarDetail
{
    public Car Car { get; set; } = new Car
    {
        Body = new Body(),
        Interior = new Interior(),
        Performance = new Performance(),
        Engine = new Engine(),
        MotorX = new Motor(),
        MotorY = new Motor(),
        Battery = new Battery(),
        TireFront = new Tire(),
        TireRear = new Tire(),
        Transmission = new Transmission(),
    };

    [Parameter]
    public int Id { get; set; }

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        Car = await GetCar(this.Id);
    }

    private async Task<Car> GetCar(int id)
    {
        return await CarRepo.GetCar(id);
    }
}
