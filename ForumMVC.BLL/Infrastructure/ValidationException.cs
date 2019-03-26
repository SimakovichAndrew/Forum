﻿using System;



namespace ForumMVC.BLL.Infrastructure
{
    //Класс ValidationException наследуется от базового класса исключений Exception и определяет свойство Property. Это свойство позволяет сохранить название свойства модели, которое некорректно и не проходит валидацию. И также передавая в конструктор базового класса параметр message, мы определяем сообщение, которое будет выводиться для некорректного свойства в Property.//
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
