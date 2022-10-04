<?php
    function component($productname, $productprice, $productBeforePrice, $productimg, $productid, $product_evaluation){
        if($productBeforePrice != 0){
            $napis1 = "<small><s class=\"text-secondary\">$productBeforePrice zł</s></small>";
        } else{
            $napis1 = "";
        }

        switch ($product_evaluation){
            case 1:
                $star = "<i class=\"fas fa-star\"></i>
                        <i class=\"far fa-star\"></i>
                        <i class=\"far fa-star\"></i>
                        <i class=\"far fa-star\"></i>
                        <i class=\"far fa-star\"></i>";
                break;
            case 2:
                $star = "<i class=\"fas fa-star\"></i>
                         <i class=\"fas fa-star\"></i>
                         <i class=\"far fa-star\"></i>
                         <i class=\"far fa-star\"></i>
                         <i class=\"far fa-star\"></i>";
                break;
            case 3:
                $star = "<i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>
                        <i class=\"far fa-star\"></i>
                        <i class=\"far fa-star\"></i>";
            break;
            case 4:
                $star = "<i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>
                        <i class=\"far fa-star\"></i>";
            break;
            case 5:
                $star = "<i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>
                        <i class=\"fas fa-star\"></i>";
            break;
            default:
                $star = "Brak oceny produktu.";
                break;
        }

        $element = "
        <div class=\"col-md-3 col-sm-6 my-3 my-md-0\">
        <form action=\"index.php\" method=\"post\">
            <div class=\"card shadow\">
                <div>
                    <img src=\"./images/$productimg\" alt=\"Image1\" class=\"img-fluid card-img-top\">
                </div>
                <div class=\"card-body\">
                    <h5 class=\"card-title\">$productname</h5>
                    <h6>
                        $star
                    </h6>

                    <h5>
                        $napis1
                        <span class=\"price\">$productprice zł</span>
                    </h5>
                    <button type=\"submit\" class=\"btn btn-warning my-3\" name=\"add\">Dodaj do koszyka <i class=\"fas fa-shopping-cart\"></i></button>
                     <input type='hidden' name='product_id' value='$productid'>
                </div>
            </div>
        </form>
    </div>
        ";
        echo $element;
    }

function cartElement($productimg, $productname, $productprice, $productid)
{
    $element = "
    
    <form action=\"cart.php?action=remove&id=$productid\" method=\"post\" class=\"cart-items\">
                    <div class=\"border rounded\">
                        <div class=\"row bg-white\">
                            <div class=\"col-md-3 pl-0\">
                                <img src=./images/$productimg alt=\"Image1\" class=\"img-fluid\">
                            </div>
                            <div class=\"col-md-6\">
                                <h5 class=\"pt-2\">$productname</h5>
                                
                                <h5 class=\"pt-2\">$productprice zł</h5>
                                <button type=\"submit\" class=\"btn btn-danger mx-2\" name=\"remove\">Usuń z koszyka</button>
                            </div>
                        </div>
                    </div>
                </form>
    
    ";
    echo $element;
}
?>