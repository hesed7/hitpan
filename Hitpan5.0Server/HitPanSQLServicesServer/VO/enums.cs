using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitPanSQLServicesServer.VO
{
    public enum 입력유효성검사 
    {
        정상,
        서비스URL이_기존서비스와_중복,
        서비스URL이_주소형식에_맞지_않음,
        서비스URL이_입력되지_않음,
        포트번호가_형식에_맞지_않음,
        Primary_DB파일경로가_없음,
        백업경로가_입력되지_않음
    };

    public enum 자동백업시간간격 
    {
        자동백업_사용안함,삼십분,한시간,열두시간,하루,삼일,오일, 일주일,이주일
    }
}
