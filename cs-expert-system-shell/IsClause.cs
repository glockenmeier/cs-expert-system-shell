﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chen0040.ExpertSystem
{
    public class IsClause : Clause
    {
        public IsClause(string variable, string value)
            : base(variable, value)
        {
            m_condition = "=";
        }

        protected override IntersectionType intersect(Clause rhs)
	    {	
		    if(rhs is IsClause)
		    {
			    if(m_value==rhs.getValue())
			    {
				    return IntersectionType.INCLUDE;
			    }
			    else
			    {
				    return IntersectionType.MUTUALLY_EXCLUDE;
			    }
		    }
		
		    string v1=m_value;
		    string v2=rhs.getValue();
		
		    double a=0;
		    double b=0;
		
		    if(double.TryParse(v1, out a) && double.TryParse(v2, out b))
            {
		        if(rhs is LessClause)
		        {			
			        if(a >= b)
			        {
				        return IntersectionType.MUTUALLY_EXCLUDE;
			        }
			        else
			        {
				        return IntersectionType.INCLUDE;
			        }
		        }
		        else if(rhs is LEClause)
		        {
			        if(a > b)
			        {
				        return IntersectionType.MUTUALLY_EXCLUDE;
			        }
			        else
			        {
				        return IntersectionType.INCLUDE;
			        }
		        }
		        else if(rhs is GreaterClause)
		        {			
			        if(a <= b)
			        {
				        return IntersectionType.MUTUALLY_EXCLUDE;
			        }
			        else
			        {
				        return IntersectionType.INCLUDE;
			        }
		        }
		        else if(rhs is GEClause)
		        {
			        if(a < b)
			        {
				        return IntersectionType.MUTUALLY_EXCLUDE;
			        }
			        else
			        {
				        return IntersectionType.INCLUDE;
			        }
		        }
		        else
		        {
			        return IntersectionType.UNKNOWN;
		        }
            }
            else
            {
                return IntersectionType.UNKNOWN;
            }
	    }
    }
}
