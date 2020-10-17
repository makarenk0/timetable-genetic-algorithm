﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TimetableGeneticGeneration
{
    class Lesson
    {
        private Utilities.LessonType _type;
        private String _subject;
        private String _teacher;
        private String _group;
        private int _audience;
        private bool _free;

        public String Teacher
        {
            get { return _teacher; }
        }

        public int Audience
        {
            get { return _audience; }
        }

        public Lesson()
        {
            _free = true;
        }

        public override string ToString()
        {
            String type = _type == Utilities.LessonType.Lecture ? "Lecture" : "Practice";
            return _free ? "free" : String.Concat(_type, ", ", _subject, ", ", _teacher, ", Audience: ", _audience, ", ", _group);
        }

        public bool IsFree
        {
            get { return _free; }
            set { }
        }

        public void FillForHour(String group, String subject, Utilities.LessonType type, JsonElement root)
        {
            _type = type;
            Dictionary<String, String> _subjectLecturer = Utilities.GetAsObjectJSON(root, "Subject_lecturer", "Subject");
            string[] teachers = Utilities.GetAsObjectJSON<string[]>(root, "Teacher");
            int[] audiences = Utilities.GetAsObjectJSON<int[]>(root, "Audience");
            if (type == Utilities.LessonType.Lecture)
            {
                _teacher = _subjectLecturer[subject];
            }
            else
            {
                int choosedTeacher = Utilities.ChooseRandomly(0, teachers.Length);
                _teacher = teachers[choosedTeacher];
            }
            _subject = subject;
            _group = group;
            _audience = audiences[Utilities.ChooseRandomly(0, audiences.Length)];
            _free = false;
        }
    }
}
