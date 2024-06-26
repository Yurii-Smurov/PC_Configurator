﻿namespace Configurator.Models.Components
{
    sealed class SoundCard : PCComponent
    {
        public SoundCard()
        {
            Type = ComponentType.SoundCard;
        }

        public SoundCard(string name, decimal price, string manufacturer, int stock, string form) : base(name, price, manufacturer, stock)
        {
            Form = form;

            Type = ComponentType.SoundCard;
        }

        public string Form { get; set; } = null!;
    }
}
